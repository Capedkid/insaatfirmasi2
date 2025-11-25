using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using InsaatFirmasi.Data;
using InsaatFirmasi.Models;

namespace InsaatFirmasi.Controllers;

[Authorize]
public class AdminBlogController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminBlogController> _logger;
    private readonly IWebHostEnvironment _env;

    public AdminBlogController(
        ApplicationDbContext context,
        ILogger<AdminBlogController> logger,
        IWebHostEnvironment env)
    {
        _context = context;
        _logger = logger;
        _env = env;
    }

    // Blog yazılarını listele ve yeni yazı formunu göster
    public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
    {
        var query = _context.BlogPosts
            .OrderByDescending(b => b.PublishedDate ?? b.CreatedDate);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var posts = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalCount = totalCount;

        return View(posts);
    }

    // Yeni blog yazısı oluştur
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogPost post, IFormFile? imageFile)
    {
        if (!ModelState.IsValid)
        {
            var postsForInvalid = await _context.BlogPosts
                .OrderByDescending(b => b.PublishedDate ?? b.CreatedDate)
                .ToListAsync();

            return View("Index", postsForInvalid);
        }

        // Kapak görseli yükleme (isteğe bağlı)
        if (imageFile != null && imageFile.Length > 0)
        {
            try
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "blog");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                post.ImagePath = Path.Combine("uploads", "blog", uniqueFileName).Replace("\\", "/");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog kapak görseli yüklenirken bir hata oluştu.");
                ModelState.AddModelError(string.Empty, "Kapak görseli yüklenirken bir hata oluştu. Lütfen tekrar deneyin.");

                var postsForError = await _context.BlogPosts
                    .OrderByDescending(b => b.PublishedDate ?? b.CreatedDate)
                    .ToListAsync();

                return View("Index", postsForError);
            }
        }

        // Varsayılanlar
        post.IsActive = true;
        post.CreatedDate = DateTime.Now;
        if (post.IsPublished && !post.PublishedDate.HasValue)
        {
            post.PublishedDate = DateTime.Now;
        }

        _context.BlogPosts.Add(post);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlogPost updatedPost, IFormFile? imageFile)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(post);
        }

        try
        {
            post.Title = updatedPost.Title;
            post.TitleEn = updatedPost.TitleEn;
            post.Summary = updatedPost.Summary;
            post.SummaryEn = updatedPost.SummaryEn;
            post.Category = updatedPost.Category;
            post.Tags = updatedPost.Tags;
            post.Content = updatedPost.Content;
            post.ContentEn = updatedPost.ContentEn;
            post.IsFeatured = updatedPost.IsFeatured;

            // Yayın durumu
            var wasPublished = post.IsPublished;
            post.IsPublished = updatedPost.IsPublished;
            if (!wasPublished && post.IsPublished && !post.PublishedDate.HasValue)
            {
                post.PublishedDate = DateTime.Now;
            }

            // Kapak görseli güncelleme (isteğe bağlı)
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    if (!string.IsNullOrEmpty(post.ImagePath))
                    {
                        var oldPath = Path.Combine(
                            _env.WebRootPath,
                            post.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
                        );

                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Blog güncellenirken eski kapak görseli silinemedi.");
                }

                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "blog");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                post.ImagePath = Path.Combine("uploads", "blog", uniqueFileName).Replace("\\", "/");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Blog yazısı güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Blog yazısı güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
            return View(post);
        }
    }

    // Blog yazısını sil
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post != null)
        {
            try
            {
                if (!string.IsNullOrEmpty(post.ImagePath))
                {
                    var physicalPath = Path.Combine(
                        _env.WebRootPath,
                        post.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
                    );

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Blog yazısı silinirken kapak görseli silinemedi.");
            }

            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // Blog yazısı yayın durumunu değiştir
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TogglePublish(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.IsPublished = !post.IsPublished;
        if (post.IsPublished && !post.PublishedDate.HasValue)
        {
            post.PublishedDate = DateTime.Now;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}


