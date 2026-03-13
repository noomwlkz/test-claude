using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages.MyBookings;

public class IndexModel : PageModel
{
    private readonly AssetService _assetService;

    public IndexModel(AssetService assetService) => _assetService = assetService;

    public List<AssetBooking> Bookings        { get; set; } = new();
    public int                TotalCount      { get; set; }
    public int                ConfirmedCount  { get; set; }
    public int                CancelledCount  { get; set; }

    public void OnGet() => LoadData();

    private void LoadData()
    {
        Bookings       = _assetService.GetAllBookings();
        TotalCount     = Bookings.Count;
        ConfirmedCount = Bookings.Count(b => b.Status == BookingStatus.Confirmed);
        CancelledCount = Bookings.Count(b => b.Status == BookingStatus.Cancelled);
    }

    public IActionResult OnPostCancel(int bookingId)
    {
        var ok = _assetService.CancelBooking(bookingId);
        TempData[ok ? "Success" : "Error"] = ok
            ? "ยกเลิกการจองเรียบร้อยแล้ว"
            : "ไม่พบข้อมูลการจอง หรือถูกยกเลิกไปแล้ว";
        return RedirectToPage();
    }
}
