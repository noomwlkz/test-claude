using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Pages.CustomerRegister;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;

    [BindProperty(SupportsGet = true)] public string Phone  { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)] public string IdCard { get; set; } = string.Empty;

    [BindProperty] public string  Title_    { get; set; } = string.Empty;
    [BindProperty] public string  Name      { get; set; } = string.Empty;
    [BindProperty] public string  Surname   { get; set; } = string.Empty;
    [BindProperty] public string  Address   { get; set; } = string.Empty;

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname)
            || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(IdCard))
        {
            ModelState.AddModelError(string.Empty, "กรุณากรอกข้อมูลที่จำเป็นให้ครบถ้วน");
            return Page();
        }

        var phone  = Phone.Trim().Replace("-", "").Replace(" ", "");
        var idcard = IdCard.Trim().Replace("-", "").Replace(" ", "");

        // ป้องกัน duplicate
        var exists = _db.CustomerLists.Any(c => c.Ssn == idcard || c.TelNum == phone);
        if (exists)
        {
            ModelState.AddModelError(string.Empty, "เบอร์โทรหรือเลขบัตรประชาชนนี้มีในระบบแล้ว กรุณาเข้าสู่ระบบ");
            return Page();
        }

        var custKey = $"C{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(100, 999)}";

        var customer = new CustomerList
        {
            CustKey    = custKey,
            Ssn        = idcard,
            TelNum     = phone,
            Title      = Title_.Trim(),
            Name       = Name.Trim(),
            Surname    = Surname.Trim(),
            Address    = Address.Trim(),
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        _db.CustomerLists.Add(customer);
        await _db.SaveChangesAsync();

        HttpContext.Session.SetString("CustKey",  custKey);
        HttpContext.Session.SetString("CustName", $"{Title_.Trim()}{Name.Trim()} {Surname.Trim()}".Trim());

        return RedirectToPage("/MyAssets/Index");
    }
}
