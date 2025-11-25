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

    private string GetHeaderLogoSettingsFilePath()
    {
        var settingsFolder = Path.Combine(_env.WebRootPath, "uploads", "settings");
        if (!Directory.Exists(settingsFolder))
        {
            Directory.CreateDirectory(settingsFolder);
        }
        return Path.Combine(settingsFolder, "header-logo-settings.txt");
    }

    public async Task<IActionResult> Index()
    {
        var logos = await _context.SiteLogos
            .OrderByDescending(l => l.CreatedDate)
            .ToListAsync();

        // Footer alt sayfa adı (TR / EN)
        try
        {
            var footerPath = GetFooterTextFilePath();
            if (System.IO.File.Exists(footerPath))
            {
                var lines = await System.IO.File.ReadAllLinesAsync(footerPath);
                ViewBag.FooterTextTr = lines.Length > 0 && !string.IsNullOrWhiteSpace(lines[0])
                    ? lines[0]
                    : "İnşaat Plastik Çözümler";
                ViewBag.FooterTextEn = lines.Length > 1 && !string.IsNullOrWhiteSpace(lines[1])
                    ? lines[1]
                    : "Construction Plastic Solutions";
            }
            else
            {
                ViewBag.FooterTextTr = "İnşaat Plastik Çözümler";
                ViewBag.FooterTextEn = "Construction Plastic Solutions";
            }
        }
        catch
        {
            ViewBag.FooterTextTr = "İnşaat Plastik Çözümler";
            ViewBag.FooterTextEn = "Construction Plastic Solutions";
        }

        // Footer sol alan (başlık, alt başlık, açıklama - TR / EN)
        try
        {
            var brandPath = GetFooterBrandFilePath();
            if (System.IO.File.Exists(brandPath))
            {
                var lines = await System.IO.File.ReadAllLinesAsync(brandPath);
                ViewBag.FooterBrandTitleTr = lines.Length > 0 ? lines[0] : null;
                ViewBag.FooterBrandSubtitleTr = lines.Length > 1 ? lines[1] : null;
                ViewBag.FooterBrandDescriptionTr = lines.Length > 2 ? lines[2] : null;
                ViewBag.FooterBrandTitleEn = lines.Length > 3 ? lines[3] : null;
                ViewBag.FooterBrandSubtitleEn = lines.Length > 4 ? lines[4] : null;
                ViewBag.FooterBrandDescriptionEn = lines.Length > 5 ? lines[5] : null;
            }
        }
        catch
        {
            ViewBag.FooterBrandTitleTr = null;
            ViewBag.FooterBrandSubtitleTr = null;
            ViewBag.FooterBrandDescriptionTr = null;
            ViewBag.FooterBrandTitleEn = null;
            ViewBag.FooterBrandSubtitleEn = null;
            ViewBag.FooterBrandDescriptionEn = null;
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

        // Header logosu ile KONAP metni birlikte görünsün mü?
        try
        {
            var settingsPath = GetHeaderLogoSettingsFilePath();
            if (System.IO.File.Exists(settingsPath))
            {
                var raw = (await System.IO.File.ReadAllTextAsync(settingsPath)).Trim().ToLowerInvariant();
                if (raw == "true" || raw == "1" || raw == "yes")
                {
                    ViewBag.ShowKonapTextWithLogo = true;
                }
                else if (raw == "false" || raw == "0" || raw == "no")
                {
                    ViewBag.ShowKonapTextWithLogo = false;
                }
                else
                {
                    ViewBag.ShowKonapTextWithLogo = true;
                }
            }
            else
            {
                ViewBag.ShowKonapTextWithLogo = true;
            }
        }
        catch
        {
            ViewBag.ShowKonapTextWithLogo = true;
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
    public async Task<IActionResult> UpdateFooterText(string footerTextTr, string footerTextEn)
    {
        footerTextTr ??= string.Empty;
        footerTextEn ??= string.Empty;

        try
        {
            var footerPath = GetFooterTextFilePath();
            var lines = new List<string>
            {
                footerTextTr,
                footerTextEn
            };
            await System.IO.File.WriteAllLinesAsync(footerPath, lines);
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
    public async Task<IActionResult> UpdateFooterBrand(string brandTitle, string brandSubtitle, string brandDescription, string brandTitleEn, string brandSubtitleEn, string brandDescriptionEn)
    {
        try
        {
            var brandPath = GetFooterBrandFilePath();
            var lines = new List<string>
            {
                brandTitle ?? string.Empty,
                brandSubtitle ?? string.Empty,
                brandDescription ?? string.Empty,
                brandTitleEn ?? string.Empty,
                brandSubtitleEn ?? string.Empty,
                brandDescriptionEn ?? string.Empty
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateHeaderLogoSettings(string showKonapTextWithLogo)
    {
        var raw = (showKonapTextWithLogo ?? string.Empty).Trim().ToLowerInvariant();
        var flag = raw == "true" || raw == "1" || raw == "yes" || raw == "on";

        try
        {
            var settingsPath = GetHeaderLogoSettingsFilePath();
            await System.IO.File.WriteAllTextAsync(settingsPath, flag ? "true" : "false");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Header logo ayarları güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Header logo ayarları kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return RedirectToAction(nameof(Index));
    }
}


