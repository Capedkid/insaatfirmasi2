using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;
using InsaatFirmasi.Models;

namespace InsaatFirmasi.ViewComponents;

public class HeaderLogoViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public HeaderLogoViewComponent(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
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

    public async Task<IViewComponentResult> InvokeAsync()
    {
        SiteLogo? activeLogo = null;
        bool showKonapTextWithLogo = true;

        try
        {
            activeLogo = await _context.SiteLogos
                .OrderByDescending(l => l.CreatedDate)
                .FirstOrDefaultAsync();
        }
        catch
        {
            activeLogo = null;
        }

        try
        {
            var settingsPath = GetHeaderLogoSettingsFilePath();
            if (System.IO.File.Exists(settingsPath))
            {
                var raw = (await System.IO.File.ReadAllTextAsync(settingsPath)).Trim().ToLowerInvariant();
                showKonapTextWithLogo = raw == "true" || raw == "1" || raw == "yes";
            }
        }
        catch
        {
            showKonapTextWithLogo = true;
        }

        ViewBag.ShowKonapTextWithLogo = showKonapTextWithLogo;
        return View(activeLogo);
    }
}


