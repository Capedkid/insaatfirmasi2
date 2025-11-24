using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsaatFirmasi.Data;

namespace InsaatFirmasi.Controllers;

public class SeoController : Controller
{
    private readonly ApplicationDbContext _context;

    public SeoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("sitemap.xml")]
    public async Task<IActionResult> Sitemap()
    {
        var request = HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";

        var urls = new List<(string loc, DateTime? lastMod, string changeFreq, string priority)>();

        // Statik sayfalar
        urls.Add((baseUrl + Url.Action("Index", "Home"), DateTime.UtcNow, "weekly", "1.0"));
        urls.Add((baseUrl + Url.Action("About", "Home"), DateTime.UtcNow, "yearly", "0.6"));
        urls.Add((baseUrl + Url.Action("Index", "Product"), DateTime.UtcNow, "weekly", "0.9"));
        urls.Add((baseUrl + Url.Action("Index", "Blog"), DateTime.UtcNow, "weekly", "0.8"));
        urls.Add((baseUrl + Url.Action("Index", "Catalog"), DateTime.UtcNow, "monthly", "0.7"));
        urls.Add((baseUrl + Url.Action("Index", "Contact"), DateTime.UtcNow, "yearly", "0.5"));

        // Kategoriler
        var categories = await _context.Categories
            .Where(c => c.IsActive)
            .ToListAsync();

        foreach (var category in categories)
        {
            var loc = baseUrl + Url.Action("Category", "Product", new { id = category.Id });
            urls.Add((loc, category.UpdatedDate ?? category.CreatedDate, "weekly", "0.8"));
        }

        // Ürünler
        var products = await _context.Products
            .Where(p => p.IsActive)
            .ToListAsync();

        foreach (var product in products)
        {
            var loc = baseUrl + Url.Action("Details", "Product", new { id = product.Id });
            urls.Add((loc, product.UpdatedDate ?? product.CreatedDate, "weekly", "0.9"));
        }

        // Blog yazıları
        var posts = await _context.BlogPosts
            .Where(b => b.IsActive && b.PublishedDate.HasValue)
            .ToListAsync();

        foreach (var post in posts)
        {
            var loc = baseUrl + Url.Action("Details", "Blog", new { id = post.Id });
            urls.Add((loc, post.UpdatedDate ?? post.PublishedDate ?? post.CreatedDate, "weekly", "0.7"));
        }

        // Kataloglar
        var catalogs = await _context.Catalogs
            .Where(c => c.IsActive)
            .ToListAsync();

        foreach (var catalog in catalogs)
        {
            var loc = baseUrl + Url.Action("View", "Catalog", new { id = catalog.Id });
            urls.Add((loc, catalog.UpdatedDate ?? catalog.CreatedDate, "monthly", "0.6"));
        }

        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

        foreach (var url in urls)
        {
            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{System.Security.SecurityElement.Escape(url.loc)}</loc>");
            if (url.lastMod.HasValue)
            {
                sb.AppendLine($"    <lastmod>{url.lastMod.Value:yyyy-MM-dd}</lastmod>");
            }
            sb.AppendLine($"    <changefreq>{url.changeFreq}</changefreq>");
            sb.AppendLine($"    <priority>{url.priority}</priority>");
            sb.AppendLine("  </url>");
        }

        sb.AppendLine("</urlset>");

        return Content(sb.ToString(), "application/xml", Encoding.UTF8);
    }
}


