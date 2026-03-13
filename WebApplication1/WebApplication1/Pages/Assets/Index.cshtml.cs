using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Assets;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db) => _db = db;

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

    public async Task<IActionResult> OnGetAsync()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("CustKey")))
            return RedirectToPage("/Login/Index");

        var q = _db.AssetMasters.AsNoTracking().AsQueryable();

        // Search
        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var t = SearchTerm.Trim();
            q = q.Where(a => (a.AssetNo != null && a.AssetNo.Contains(t))
                          || (a.AssetName != null && a.AssetName.Contains(t))
                          || (a.Province  != null && a.Province.Contains(t))
                          || (a.District  != null && a.District.Contains(t))
                          || (a.AssetType != null && a.AssetType.Contains(t)));
        }

        // Filters
        if (!string.IsNullOrWhiteSpace(FilterType))     q = q.Where(a => a.AssetType == FilterType);
        if (!string.IsNullOrWhiteSpace(FilterProvince)) q = q.Where(a => a.Province  == FilterProvince);
        if (!string.IsNullOrWhiteSpace(FilterStatus))
        {
            var flg = FilterStatus switch
            {
                "available" => "A",
                "locked"    => "L",
                "sold"      => "S",
                _           => null
            };
            if (flg != null) q = q.Where(a => a.StatusFlg == flg);
        }

        // Sort
        q = SortBy switch
        {
            "price_asc"  => q.OrderBy(a => a.Price),
            "price_desc" => q.OrderByDescending(a => a.Price),
            "code_asc"   => q.OrderBy(a => a.AssetNo),
            "newest"     => q.OrderByDescending(a => a.Created),
            _            => q.OrderBy(a => a.AssetNo)
        };

        // Count + paginate in DB
        TotalCount = await q.CountAsync();
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        PageNumber = Math.Max(1, Math.Min(PageNumber, Math.Max(1, TotalPages)));

        var rows = await q.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();

        Assets = rows.Select((a, i) => new Asset
        {
            Id             = i,
            AssetDbId      = a.AssetId,
            AssetCode      = a.AssetNo ?? a.AssetId,
            AssetType      = a.AssetType ?? "-",
            TitleDeedType  = a.DeedNo ?? "-",
            Province       = a.Province ?? "-",
            District       = a.District ?? "-",
            SizeText       = a.Size ?? string.Empty,
            SellingPrice   = decimal.TryParse(a.Price, out var p) ? p : 0m,
            AppraisedPrice = decimal.TryParse(a.Price, out var p2) ? p2 : 0m,
            Status         = a.StatusFlg switch
            {
                "A" => AssetStatus.Available,
                "L" => AssetStatus.Locked,
                "S" => AssetStatus.Sold,
                _   => AssetStatus.Available
            },
            Description = a.AssetName ?? string.Empty,
            ImgUrl      = a.ImgUrl,
        }).ToList();

        // Filter dropdowns — distinct values from entire table
        Provinces  = await _db.AssetMasters.AsNoTracking()
                        .Where(a => a.Province != null)
                        .Select(a => a.Province!)
                        .Distinct().OrderBy(x => x).ToListAsync();

        AssetTypes = await _db.AssetMasters.AsNoTracking()
                        .Where(a => a.AssetType != null)
                        .Select(a => a.AssetType!)
                        .Distinct().OrderBy(x => x).ToListAsync();

        return Page();
    }
}
