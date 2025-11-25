using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;
using InsaatFirmasi.Models;

namespace InsaatFirmasi.ViewComponents;

public class HeaderCategoriesViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public HeaderCategoriesViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var baseQuery = _context.Categories
            .Where(c => c.IsActive);

        var totalActiveCount = await baseQuery.CountAsync();

        var categories = await baseQuery
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .Take(8)
            .ToListAsync();

        ViewBag.HasMoreCategories = totalActiveCount > 8;

        return View(categories);
    }
}


