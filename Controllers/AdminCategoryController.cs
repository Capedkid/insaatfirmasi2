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
public class AdminCategoryController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminCategoryController> _logger;
    private readonly IWebHostEnvironment _env;

    public AdminCategoryController(
        ApplicationDbContext context,
        ILogger<AdminCategoryController> logger,
        IWebHostEnvironment env)
    {
        _context = context;
        _logger = logger;
        _env = env;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
    {
        var query = _context.Categories
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var categories = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalCount = totalCount;

        return View(categories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category, IFormFile? imageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "categories");
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

                    category.ImagePath = Path.Combine("uploads", "categories", uniqueFileName).Replace("\\", "/");
                }

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori oluşturulurken bir hata oluştu.");
                ModelState.AddModelError(string.Empty, "Kategori kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
            }
        }

        var categories = await _context.Categories
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .ToListAsync();

        return View("Index", categories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Category updatedCategory, IFormFile? imageFile)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(category);
        }

        try
        {
            category.Name = updatedCategory.Name;
            category.NameEn = updatedCategory.NameEn;
            category.Description = updatedCategory.Description;
            category.DescriptionEn = updatedCategory.DescriptionEn;

            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    if (!string.IsNullOrEmpty(category.ImagePath))
                    {
                        var oldPath = Path.Combine(
                            _env.WebRootPath,
                            category.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
                        );

                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Kategori güncellenirken eski görsel silinemedi.");
                }

                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "categories");
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

                category.ImagePath = Path.Combine("uploads", "categories", uniqueFileName).Replace("\\", "/");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Kategori güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Kategori güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
            return View(category);
        }
    }
}

