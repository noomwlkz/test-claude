using WebApplication1.Models;

namespace WebApplication1.Services;

public class AssetService
{
    private static readonly List<Asset> _assets;
    private static readonly List<AssetBooking> _bookings = new();
    private static int _bookingCounter = 1;

    static AssetService()
    {
        _assets = GenerateMockAssets();
    }

    private static List<Asset> GenerateMockAssets()
    {
        var rng = new Random(42);
        var assets = new List<Asset>();

        var provinces = new[]
        {
            "กรุงเทพมหานคร", "นนทบุรี", "ปทุมธานี", "สมุทรปราการ",
            "เชียงใหม่", "ขอนแก่น", "ชลบุรี", "ระยอง", "ภูเก็ต",
            "สงขลา", "เชียงราย", "นครราชสีมา", "อุดรธานี", "สุราษฎร์ธานี", "นครปฐม"
        };

        var districtMap = new Dictionary<string, string[]>
        {
            ["กรุงเทพมหานคร"] = ["บางรัก", "สาทร", "ลาดกระบัง", "มีนบุรี", "ลาดพร้าว", "บางเขน", "จตุจักร", "ดอนเมือง", "บางนา", "พระโขนง"],
            ["นนทบุรี"]       = ["เมืองนนทบุรี", "บางใหญ่", "บางบัวทอง", "ปากเกร็ด"],
            ["ปทุมธานี"]      = ["เมืองปทุมธานี", "ลำลูกกา", "คลองหลวง", "ธัญบุรี"],
            ["สมุทรปราการ"]   = ["เมืองสมุทรปราการ", "บางพลี", "พระประแดง", "บางบ่อ"],
            ["เชียงใหม่"]     = ["เมืองเชียงใหม่", "หางดง", "สันทราย", "สันกำแพง", "ดอยสะเก็ด"],
            ["ขอนแก่น"]       = ["เมืองขอนแก่น", "บ้านไผ่", "พล", "น้ำพอง"],
            ["ชลบุรี"]        = ["เมืองชลบุรี", "บางละมุง", "ศรีราชา", "สัตหีบ"],
            ["ระยอง"]         = ["เมืองระยอง", "บ้านค่าย", "นิคมพัฒนา", "มาบตาพุด"],
            ["ภูเก็ต"]        = ["เมืองภูเก็ต", "กะทู้", "ถลาง"],
            ["สงขลา"]         = ["เมืองสงขลา", "หาดใหญ่", "สิงหนคร"],
            ["เชียงราย"]      = ["เมืองเชียงราย", "เชียงแสน", "แม่จัน", "แม่สาย"],
            ["นครราชสีมา"]    = ["เมืองนครราชสีมา", "ปากช่อง", "สีคิ้ว", "โชคชัย"],
            ["อุดรธานี"]      = ["เมืองอุดรธานี", "กุมภวาปี", "หนองบัวลำภู"],
            ["สุราษฎร์ธานี"]  = ["เมืองสุราษฎร์ธานี", "เกาะสมุย", "เกาะพะงัน"],
            ["นครปฐม"]        = ["เมืองนครปฐม", "สามพราน", "พุทธมณฑล", "บางเลน"]
        };

        var assetTypes   = new[] { "ที่ดินเปล่า", "บ้านเดี่ยว", "ทาวน์เฮ้าส์", "คอนโดมิเนียม", "อาคารพาณิชย์", "โรงงาน", "สวน/ไร่นา" };
        var titleDeeds   = new[] { "โฉนดที่ดิน", "นส.3", "นส.3ก", "ส.ค.1" };
        var descriptions = new[]
        {
            "ทำเลดี ใกล้แหล่งชุมชน", "ติดถนนใหญ่ สะดวกสบาย",
            "ใกล้โรงเรียน โรงพยาบาล", "ใกล้ทางด่วน สะดวกเดินทาง",
            "ติดแนวรถไฟฟ้า", "ใกล้ห้างสรรพสินค้า",
            "ทำเลศักยภาพสูง", "ราคาน่าสนใจ คุ้มค่าลงทุน",
            "บรรยากาศดี ร่มรื่น", "ใกล้สถานที่ราชการ"
        };

        for (int i = 1; i <= 100; i++)
        {
            var province  = provinces[rng.Next(provinces.Length)];
            var districts = districtMap.GetValueOrDefault(province, ["เมือง"]);
            var district  = districts[rng.Next(districts.Length)];
            var assetType = assetTypes[rng.Next(assetTypes.Length)];
            bool isCondo  = assetType == "คอนโดมิเนียม";

            var basePrice = assetType switch
            {
                "ที่ดินเปล่า"   => rng.Next(500,   8000)  * 1000m,
                "บ้านเดี่ยว"    => rng.Next(1500,  15000) * 1000m,
                "ทาวน์เฮ้าส์"   => rng.Next(800,   5000)  * 1000m,
                "คอนโดมิเนียม"  => rng.Next(500,   6000)  * 1000m,
                "อาคารพาณิชย์"  => rng.Next(2000,  20000) * 1000m,
                "โรงงาน"        => rng.Next(5000,  50000) * 1000m,
                _               => rng.Next(300,   5000)  * 1000m
            };

            var r = rng.Next(100);
            var status = r < 60 ? AssetStatus.Available
                       : r < 85 ? AssetStatus.Locked
                       :           AssetStatus.Sold;

            assets.Add(new Asset
            {
                Id             = i,
                AssetCode      = $"ทส.{65000 + i:D6}",
                AssetType      = assetType,
                TitleDeedType  = titleDeeds[rng.Next(titleDeeds.Length)],
                Province       = province,
                District       = district,
                AreaRai        = isCondo ? 0 : rng.Next(0, 5),
                AreaNgan       = isCondo ? 0 : rng.Next(0, 4),
                AreaWa         = isCondo ? rng.Next(28, 150) : rng.Next(0, 99),
                AppraisedPrice = Math.Round(basePrice * 1.2m, 0),
                SellingPrice   = basePrice,
                Status         = status,
                Description    = descriptions[rng.Next(descriptions.Length)]
            });
        }

        return assets;
    }

    // ───── Queries ─────────────────────────────────────────────────────────────

    public IEnumerable<Asset> GetAssets(
        string? search     = null,
        string? assetType  = null,
        string? province   = null,
        AssetStatus? status = null,
        decimal? minPrice  = null,
        decimal? maxPrice  = null,
        string? sortBy     = null)
    {
        var q = _assets.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var t = search.Trim();
            q = q.Where(a => a.AssetCode.Contains(t) || a.Province.Contains(t)
                           || a.District.Contains(t) || a.AssetType.Contains(t));
        }
        if (!string.IsNullOrWhiteSpace(assetType)) q = q.Where(a => a.AssetType == assetType);
        if (!string.IsNullOrWhiteSpace(province))  q = q.Where(a => a.Province  == province);
        if (status.HasValue)    q = q.Where(a => a.Status       == status.Value);
        if (minPrice.HasValue)  q = q.Where(a => a.SellingPrice >= minPrice.Value);
        if (maxPrice.HasValue)  q = q.Where(a => a.SellingPrice <= maxPrice.Value);

        return sortBy switch
        {
            "price_asc"  => q.OrderBy(a => a.SellingPrice),
            "price_desc" => q.OrderByDescending(a => a.SellingPrice),
            "code_asc"   => q.OrderBy(a => a.AssetCode),
            "newest"     => q.OrderByDescending(a => a.Id),
            _            => q.OrderBy(a => a.Id)
        };
    }

    public Asset?        GetAssetById(int id)  => _assets.FirstOrDefault(a => a.Id == id);
    public List<string>  GetAllProvinces()     => [.. _assets.Select(a => a.Province).Distinct().Order()];
    public List<string>  GetAllAssetTypes()    => [.. _assets.Select(a => a.AssetType).Distinct().Order()];
    public int           GetTotalCount()       => _assets.Count;
    public int           GetAvailableCount()   => _assets.Count(a => a.Status == AssetStatus.Available);

    // ───── Bookings ────────────────────────────────────────────────────────────

    public AssetBooking? BookAsset(int assetId, string customerName, string customerPhone, string? customerIdCard)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == assetId && a.Status == AssetStatus.Available);
        if (asset is null) return null;

        asset.Status = AssetStatus.Locked;

        var seq = _bookingCounter++;
        var booking = new AssetBooking
        {
            Id           = seq,
            AssetId      = assetId,
            Asset        = asset,
            BookingNo    = $"BK{DateTime.Now:yyyyMMdd}{seq:D4}",
            BookedAt     = DateTime.Now,
            Status       = BookingStatus.Confirmed,
            CustomerName  = customerName,
            CustomerPhone = customerPhone,
            CustomerIdCard = customerIdCard ?? string.Empty
        };

        _bookings.Add(booking);
        return booking;
    }

    public List<AssetBooking> GetAllBookings() => [.. _bookings];

    public bool CancelBooking(int bookingId)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == bookingId && b.Status != BookingStatus.Cancelled);
        if (booking is null) return false;

        booking.Status = BookingStatus.Cancelled;
        var asset = _assets.FirstOrDefault(a => a.Id == booking.AssetId);
        if (asset?.Status == AssetStatus.Locked)
            asset.Status = AssetStatus.Available;

        return true;
    }
}
