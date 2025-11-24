using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;
using InsaatFirmasi.Models;

namespace InsaatFirmasi.Controllers;

[Authorize]
public class AdminLogoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminLogoController> _logger;
    private readonly IWebHostEnvironment _env;

    public AdminLogoController(
        ApplicationDbContext context,
        ILogger<AdminLogoController> logger,
        IWebHostEnvironment env)
    {
        _context = context;
        _logger = logger;
        _env = env;
    }

    private string GetFooterTextFilePath()
    {
        var settingsFolder = Path.Combine(_env.WebRootPath, "uploads", "settings");
        if (!Directory.Exists(settingsFolder))
        {
            Directory.CreateDirectory(settingsFolder);
        }
        return Path.Combine(settingsFolder, "footer-text.txt");
    }

    private string GetFooterBrandFilePath()
    {
        var settingsFolder = Path.Combine(_env.WebRootPath, "uploads", "settings");
        if (!Directory.Exists(settingsFolder))
        {
            Directory.CreateDirectory(settingsFolder);
        }
        return Path.Combine(settingsFolder, "footer-brand.txt");
    }

    private string GetSiteDescriptionFilePath()
    {
        var settingsFolder = Path.Combine(_env.WebRootPath, "uploads", "settings");
        if (!Directory.Exists(settingsFolder))
        {
            Directory.CreateDirectory(settingsFolder);
        }
        return Path.Combine(settingsFolder, "site-description.txt");
    }

    private string GetFaviconPhysicalPath()
    {
        var settingsFolder = Path.Combine(_env.WebRootPath, "uploads", "settings");
        if (!Directory.Exists(settingsFolder))
        {
            Directory.CreateDirectory(settingsFolder);
        }
        return Path.Combine(settingsFolder, "favicon.ico");
    }

    public async Task<IActionResult> Index()
    {
        var logos = await _context.SiteLogos
            .OrderByDescending(l => l.CreatedDate)
            .ToListAsync();

        // Footer alt sayfa adı
        try
        {
            var footerPath = GetFooterTextFilePath();
            if (System.IO.File.Exists(footerPath))
            {
                ViewBag.FooterText = await System.IO.File.ReadAllTextAsync(footerPath);
            }
            else
            {
                ViewBag.FooterText = "İnşaat Plastik Çözümler";
            }
        }
        catch
        {
            ViewBag.FooterText = "İnşaat Plastik Çözümler";
        }

        // Footer sol alan (başlık, alt başlık, açıklama)
        try
        {
            var brandPath = GetFooterBrandFilePath();
            if (System.IO.File.Exists(brandPath))
            {
                var lines = await System.IO.File.ReadAllLinesAsync(brandPath);
                ViewBag.FooterBrandTitle = lines.Length > 0 ? lines[0] : null;
                ViewBag.FooterBrandSubtitle = lines.Length > 1 ? lines[1] : null;
                ViewBag.FooterBrandDescription = lines.Length > 2 ? lines[2] : null;
            }
        }
        catch
        {
            ViewBag.FooterBrandTitle = null;
            ViewBag.FooterBrandSubtitle = null;
            ViewBag.FooterBrandDescription = null;
        }

        // Site description
        try
        {
            var descPath = GetSiteDescriptionFilePath();
            if (System.IO.File.Exists(descPath))
            {
                ViewBag.SiteDescription = await System.IO.File.ReadAllTextAsync(descPath);
            }
        }
        catch
        {
            ViewBag.SiteDescription = null;
        }

        // Favicon var mı?
        try
        {
            var faviconPath = GetFaviconPhysicalPath();
            ViewBag.FaviconExists = System.IO.File.Exists(faviconPath);
        }
        catch
        {
            ViewBag.FaviconExists = false;
        }

        return View(logos);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Lütfen bir logo görseli seçin.");

            var logosForError = await _context.SiteLogos
                .OrderByDescending(l => l.CreatedDate)
                .ToListAsync();

            return View("Index", logosForError);
        }

        try
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "logos");
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

            var logo = new SiteLogo
            {
                ImagePath = Path.Combine("uploads", "logos", uniqueFileName).Replace("\\", "/"),
                CreatedDate = DateTime.Now
            };

            _context.SiteLogos.Add(logo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Logo yüklenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Logo kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");

            var logosForError = await _context.SiteLogos
                .OrderByDescending(l => l.CreatedDate)
                .ToListAsync();

            return View("Index", logosForError);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var logo = await _context.SiteLogos.FindAsync(id);
        if (logo != null)
        {
            try
            {
                if (!string.IsNullOrEmpty(logo.ImagePath))
                {
                    var physicalPath = Path.Combine(
                        _env.WebRootPath,
                        logo.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
                    );

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Firma logosu silinirken dosya silinemedi.");
            }

            _context.SiteLogos.Remove(logo);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateFooterText(string footerText)
    {
        if (footerText == null)
        {
            footerText = string.Empty;
        }

        try
        {
            var footerPath = GetFooterTextFilePath();
            await System.IO.File.WriteAllTextAsync(footerPath, footerText);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Alt sayfa adı güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Alt sayfa adı kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateSiteDescription(string siteDescription)
    {
        if (siteDescription == null)
        {
            siteDescription = string.Empty;
        }

        if (siteDescription.Length > 160)
        {
            siteDescription = siteDescription.Substring(0, 160);
        }

        try
        {
            var descPath = GetSiteDescriptionFilePath();
            await System.IO.File.WriteAllTextAsync(descPath, siteDescription);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Site description güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Site description kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadFavicon(IFormFile? faviconFile)
    {
        if (faviconFile == null || faviconFile.Length == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var physicalPath = GetFaviconPhysicalPath();
            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                await faviconFile.CopyToAsync(stream);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Favicon güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Favicon kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateFooterBrand(string brandTitle, string brandSubtitle, string brandDescription)
    {
        try
        {
            var brandPath = GetFooterBrandFilePath();
            var lines = new List<string>
            {
                brandTitle ?? string.Empty,
                brandSubtitle ?? string.Empty,
                brandDescription ?? string.Empty
            };
            await System.IO.File.WriteAllLinesAsync(brandPath, lines);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Footer sol alan metni güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Footer sol metni kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return RedirectToAction(nameof(Index));
    }
}


