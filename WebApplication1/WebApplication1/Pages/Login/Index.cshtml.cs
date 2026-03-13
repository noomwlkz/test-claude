using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.Login;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;

    [BindProperty] public string Phone  { get; set; } = string.Empty;
    [BindProperty] public string IdCard { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }

    public IActionResult OnGet()
    {
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustKey")))
            return RedirectToPage("/MyAssets/Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(IdCard))
        {
            ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์และเลขบัตรประชาชน";
            return Page();
        }

        var phone  = Phone.Trim().Replace("-", "").Replace(" ", "");
        var idcard = IdCard.Trim().Replace("-", "").Replace(" ", "");

        var customer = await _db.CustomerLists
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.TelNum == phone && c.Ssn == idcard);

        if (customer == null)
            return RedirectToPage("/CustomerRegister/Index", new { phone, idcard });

        HttpContext.Session.SetString("CustKey",  customer.CustKey);
        HttpContext.Session.SetString("CustName", $"{customer.Title}{customer.Name} {customer.Surname}".Trim());
        HttpContext.Session.SetString("CustSsn",  customer.Ssn ?? "");

        return RedirectToPage("/MyAssets/Index");
    }
}
