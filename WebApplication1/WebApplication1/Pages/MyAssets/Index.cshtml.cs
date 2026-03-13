using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Pages.MyAssets;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;

    public string CustName { get; set; } = string.Empty;
    public string CustKey  { get; set; } = string.Empty;
    public List<RegisterList> Registrations { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        CustKey  = HttpContext.Session.GetString("CustKey")  ?? string.Empty;
        CustName = HttpContext.Session.GetString("CustName") ?? string.Empty;

        if (string.IsNullOrEmpty(CustKey))
            return RedirectToPage("/Login/Index");

        Registrations = await _db.RegisterLists
            .AsNoTracking()
            .Where(r => r.CustKey == CustKey)
            .OrderByDescending(r => r.CreateDate)
            .ToListAsync();

        return Page();
    }
}
