namespace WebApplication1.Models;

public class AssetBooking
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public Asset? Asset { get; set; }
    public string BookingNo { get; set; } = string.Empty;
    public DateTime BookedAt { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerIdCard { get; set; } = string.Empty;

    public string StatusText => Status switch
    {
        BookingStatus.Pending   => "รอดำเนินการ",
        BookingStatus.Confirmed => "ยืนยันแล้ว",
        BookingStatus.Cancelled => "ยกเลิก",
        _                       => "ไม่ทราบ"
    };

    public string StatusBadgeClass => Status switch
    {
        BookingStatus.Pending   => "bg-warning text-dark",
        BookingStatus.Confirmed => "bg-success",
        BookingStatus.Cancelled => "bg-secondary",
        _                       => "bg-light text-dark"
    };
}

public enum BookingStatus
{
    Pending   = 0,
    Confirmed = 1,
    Cancelled = 2
}
