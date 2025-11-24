using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;

namespace InsaatFirmasi.ViewComponents;

public class HeaderLogoViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Artık veritabanından logo okunmuyor; sabit KONAP yazısı kullanılacak.
        return View();
    }
}


