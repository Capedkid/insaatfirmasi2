using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Models;
using InsaatFirmasi.Data;

namespace InsaatFirmasi.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private readonly ApplicationDbContext _context;

    public ContactController(ILogger<ContactController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // İletişim sayfası
    public async Task<IActionResult> Index()
    {
        var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync();
        if (contactInfo == null)
        {
            contactInfo = new ContactInfo();
        }

        // SEO
        ViewData["Title"] = "İletişim";
        ViewData["Description"] = "Tüm satış ve proje talepleriniz için telefon, e-posta ve adres bilgilerimize buradan ulaşabilirsiniz.";
        ViewData["Keywords"] = "iletişim bilgileri,adres,telefon,e-posta,inşaat plastik çözümler";

        return View(contactInfo);
    }

}
