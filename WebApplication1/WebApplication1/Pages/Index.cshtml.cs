using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly AssetService _assetService;

    public IndexModel(AssetService assetService) => _assetService = assetService;

    public int TotalAssets     { get; set; }
    public int AvailableAssets { get; set; }
    public int ReservedAssets  { get; set; }
    public int TotalBookings   { get; set; }

    public void OnGet()
    {
        TotalAssets     = _assetService.GetTotalCount();
        AvailableAssets = _assetService.GetAvailableCount();
        ReservedAssets  = _assetService.GetAssets(status: AssetStatus.Reserved).Count();
        TotalBookings   = _assetService.GetAllBookings().Count;
    }
}
