using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;
using InsaatFirmasi.Models;

namespace InsaatFirmasi.Controllers;

[Authorize]
public class AdminCorporateController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminCorporateController> _logger;

    public AdminCorporateController(
        ApplicationDbContext context,
        ILogger<AdminCorporateController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var content = await _context.CorporatePageContents.FirstOrDefaultAsync()
                      ?? new CorporatePageContent { Id = 1 };

        return View(content);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CorporatePageContent content)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", content);
        }

        try
        {
            var existing = await _context.CorporatePageContents.FirstOrDefaultAsync();

            if (existing == null)
            {
                content.Id = 1;
                content.UpdatedDate = DateTime.Now;
                _context.CorporatePageContents.Add(content);
            }
            else
            {
                existing.HistoryTitle = content.HistoryTitle;
                existing.HistoryTitleEn = content.HistoryTitleEn;
                existing.HistoryText1 = content.HistoryText1;
                existing.HistoryText1En = content.HistoryText1En;
                existing.HistoryText2 = content.HistoryText2;
                existing.HistoryText2En = content.HistoryText2En;

                existing.HistoryItem1Title = content.HistoryItem1Title;
                existing.HistoryItem1TitleEn = content.HistoryItem1TitleEn;
                existing.HistoryItem1Text = content.HistoryItem1Text;
                existing.HistoryItem1TextEn = content.HistoryItem1TextEn;
                existing.HistoryItem2Title = content.HistoryItem2Title;
                existing.HistoryItem2TitleEn = content.HistoryItem2TitleEn;
                existing.HistoryItem2Text = content.HistoryItem2Text;
                existing.HistoryItem2TextEn = content.HistoryItem2TextEn;
                existing.HistoryItem3Title = content.HistoryItem3Title;
                existing.HistoryItem3TitleEn = content.HistoryItem3TitleEn;
                existing.HistoryItem3Text = content.HistoryItem3Text;
                existing.HistoryItem3TextEn = content.HistoryItem3TextEn;
                existing.HistoryItem4Title = content.HistoryItem4Title;
                existing.HistoryItem4TitleEn = content.HistoryItem4TitleEn;
                existing.HistoryItem4Text = content.HistoryItem4Text;
                existing.HistoryItem4TextEn = content.HistoryItem4TextEn;

                existing.MissionTitle = content.MissionTitle;
                existing.MissionTitleEn = content.MissionTitleEn;
                existing.MissionText = content.MissionText;
                existing.MissionTextEn = content.MissionTextEn;
                existing.VisionTitle = content.VisionTitle;
                existing.VisionTitleEn = content.VisionTitleEn;
                existing.VisionText = content.VisionText;
                existing.VisionTextEn = content.VisionTextEn;

                existing.ValuesTitle = content.ValuesTitle;
                existing.ValuesTitleEn = content.ValuesTitleEn;
                existing.ValuesSubtitle = content.ValuesSubtitle;
                existing.ValuesSubtitleEn = content.ValuesSubtitleEn;
                existing.Value1Title = content.Value1Title;
                existing.Value1TitleEn = content.Value1TitleEn;
                existing.Value1Text = content.Value1Text;
                existing.Value1TextEn = content.Value1TextEn;
                existing.Value2Title = content.Value2Title;
                existing.Value2TitleEn = content.Value2TitleEn;
                existing.Value2Text = content.Value2Text;
                existing.Value2TextEn = content.Value2TextEn;
                existing.Value3Title = content.Value3Title;
                existing.Value3TitleEn = content.Value3TitleEn;
                existing.Value3Text = content.Value3Text;
                existing.Value3TextEn = content.Value3TextEn;
                existing.Value4Title = content.Value4Title;
                existing.Value4TitleEn = content.Value4TitleEn;
                existing.Value4Text = content.Value4Text;
                existing.Value4TextEn = content.Value4TextEn;

                existing.UpdatedDate = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Kurumsal sayfası metni başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Kurumsal sayfası güncellenirken bir hata oluştu.");
            ModelState.AddModelError(string.Empty, "Metin kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
            return View("Index", content);
        }
    }
}


