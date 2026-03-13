using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages.Assets;

public class IndexModel : PageModel
{
    private readonly AssetService _assetService;

    public IndexModel(AssetService assetService) => _assetService = assetService;

    [BindProperty(SupportsGet = true)] public string? SearchTerm      { get; set; }
    [BindProperty(SupportsGet = true)] public string? FilterType      { get; set; }
    [BindProperty(SupportsGet = true)] public string? FilterProvince  { get; set; }
    [BindProperty(SupportsGet = true)] public string? FilterStatus    { get; set; }
    [BindProperty(SupportsGet = true)] public string  SortBy          { get; set; } = "default";
    [BindProperty(SupportsGet = true)] public int     PageNumber      { get; set; } = 1;

    public const int PageSize = 24;

    public List<Asset>  Assets     { get; set; } = new();
    public int          TotalCount { get; set; }
    public int          TotalPages { get; set; }
    public List<string> Provinces  { get; set; } = new();
    public List<string> AssetTypes { get; set; } = new();

    // Booking form fields
    [BindProperty] public int     BookAssetId    { get; set; }
    [BindProperty] public string  CustomerName   { get; set; } = string.Empty;
    [BindProperty] public string  CustomerPhone  { get; set; } = string.Empty;
    [BindProperty] public string? CustomerIdCard { get; set; }

    public void OnGet() => LoadData();

    private void LoadData()
    {
        AssetStatus? status = FilterStatus switch
        {
            "available" => AssetStatus.Available,
            "reserved"  => AssetStatus.Reserved,
            "sold"      => AssetStatus.Sold,
            _           => null
        };

        var all = _assetService.GetAssets(SearchTerm, FilterType, FilterProvince, status, null, null, SortBy).ToList();
        TotalCount = all.Count;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        PageNumber = Math.Max(1, Math.Min(PageNumber, Math.Max(1, TotalPages)));

        Assets     = all.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        Provinces  = _assetService.GetAllProvinces();
        AssetTypes = _assetService.GetAllAssetTypes();
    }

    public IActionResult OnPostBook()
    {
        if (string.IsNullOrWhiteSpace(CustomerName) || string.IsNullOrWhiteSpace(CustomerPhone))
        {
            TempData["Error"] = "กรุณากรอกชื่อและเบอร์โทรศัพท์";
            return RedirectToPage(GetRouteValues());
        }

        var booking = _assetService.BookAsset(BookAssetId, CustomerName.Trim(), CustomerPhone.Trim(), CustomerIdCard?.Trim());
        TempData[booking is not null ? "Success" : "Error"] = booking is not null
            ? $"จองทรัพย์สำเร็จ! เลขที่การจอง: {booking.BookingNo}"
            : "ไม่สามารถจองทรัพย์นี้ได้ อาจถูกจองหรือขายไปแล้ว";

        return RedirectToPage(GetRouteValues());
    }

    private object GetRouteValues() =>
        new { SearchTerm, FilterType, FilterProvince, FilterStatus, SortBy, PageNumber };
}
