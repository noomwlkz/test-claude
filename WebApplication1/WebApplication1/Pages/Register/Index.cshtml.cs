using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Pages.Register;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public AssetMaster? Asset { get; set; }

    [TempData]
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(string assetId)
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("CustKey")))
            return RedirectToPage("/Login/Index");

        if (string.IsNullOrWhiteSpace(assetId))
            return RedirectToPage("/Assets/Index");

        Asset = await _db.AssetMasters
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AssetId == assetId);

        if (Asset == null)
        {
            ErrorMessage = $"ไม่พบข้อมูลทรัพย์รหัส {assetId}";
            return RedirectToPage("/Assets/Index");
        }

        return Page();
    }
}
