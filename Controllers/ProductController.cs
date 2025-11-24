using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Models;
using InsaatFirmasi.Data;

namespace InsaatFirmasi.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Tüm ürünleri listele
    public async Task<IActionResult> Index(int? categoryId, string? search, int page = 1, int pageSize = 12)
    {
        var query = _context.Products
            .Where(p => p.IsActive)
            .AsQueryable();

        Category? selectedCategory = null;

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
            selectedCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId.Value && c.IsActive);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                (p.Name != null && p.Name.Contains(search)) ||
                (p.Description != null && p.Description.Contains(search)) ||
                (p.ModelNumber != null && p.ModelNumber.Contains(search)));
        }

        var orderedQuery = query
            .OrderBy(p => p.SortOrder)
            .ThenBy(p => p.Name);

        var totalCount = await orderedQuery.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var products = await orderedQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var categories = await _context.Categories
            .Where(c => c.IsActive)
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .ToListAsync();

        ViewBag.Categories = categories;
        ViewBag.SelectedCategoryId = categoryId;
        ViewBag.SearchTerm = search;
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalCount = totalCount;

        // SEO
        if (selectedCategory != null)
        {
            ViewData["Title"] = selectedCategory.SeoTitle ?? $"{selectedCategory.Name} ürünleri";
            ViewData["Description"] = selectedCategory.SeoDescription ?? (string.IsNullOrWhiteSpace(selectedCategory.Description)
                ? $"{selectedCategory.Name} ürün grubu ve teknik çözümler."
                : selectedCategory.Description);
            ViewData["Keywords"] = selectedCategory.SeoKeywords ?? $"{selectedCategory.Name},ürün grubu,plastik drenaj,rögar,ıslak zemin";
        }
        else if (!string.IsNullOrWhiteSpace(search))
        {
            ViewData["Title"] = $"\"{search}\" araması - Ürünler";
            ViewData["Description"] = $"\"{search}\" terimi için eşleşen plastik drenaj, rögar ve ıslak zemin ürünleri.";
            ViewData["Keywords"] = $"{search},ürün arama,plastik drenaj,rögar,ıslak zemin";
        }
        else
        {
            ViewData["Title"] = "Ürünlerimiz";
            ViewData["Description"] = "Plastik drenaj kanalları, rögar menhol kutuları ve ıslak zemin ürünlerinden oluşan tüm ürün grubumuz.";
            ViewData["Keywords"] = "ürünler,plastik drenaj kanalı,rögar kutusu,ıslak zemin ızgarası,inşaat plastik çözümler";
        }

        return View(products);
    }

    // Ürün detayı
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

        if (product == null)
        {
            return NotFound();
        }

        // SEO
        ViewData["Title"] = product.SeoTitle ?? product.Name;
        ViewData["Description"] = product.SeoDescription
                                  ?? (!string.IsNullOrWhiteSpace(product.Description)
                                      ? product.Description
                                      : $"\"{product.Name}\" ürünü için teknik plastik inşaat çözümü.");
        ViewData["Keywords"] = product.SeoKeywords
                               ?? $"{product.Name},{product.ModelNumber},plastik drenaj,rögar,ıslak zemin";

        return View(product);
    }

    // Kategoriye göre ürünleri listele
    public async Task<IActionResult> Category(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

        if (category == null)
        {
            return NotFound();
        }

        var products = await _context.Products
            .Where(p => p.CategoryId == id && p.IsActive)
            .OrderBy(p => p.SortOrder)
            .ThenBy(p => p.Name)
            .ToListAsync();

        ViewBag.Category = category;

        return View(products);
    }

    // Arama sonuçları
    [HttpPost]
    public IActionResult Search(string searchTerm)
    {
        return RedirectToAction(nameof(Index), new { search = searchTerm });
    }
}
