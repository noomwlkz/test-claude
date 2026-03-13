namespace WebApplication1.Models;

public class Asset
{
    public int Id { get; set; }
    public string AssetCode { get; set; } = string.Empty;
    public string AssetType { get; set; } = string.Empty;
    public string TitleDeedType { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public double AreaRai { get; set; }
    public double AreaNgan { get; set; }
    public double AreaWa { get; set; }
    public decimal AppraisedPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public AssetStatus Status { get; set; } = AssetStatus.Available;
    public string Description { get; set; } = string.Empty;

    public string TypeCssClass => AssetType switch
    {
        "ที่ดินเปล่า"    => "type-land",
        "บ้านเดี่ยว"     => "type-house",
        "ทาวน์เฮ้าส์"    => "type-townhouse",
        "คอนโดมิเนียม"   => "type-condo",
        "อาคารพาณิชย์"   => "type-commercial",
        "โรงงาน"         => "type-factory",
        "สวน/ไร่นา"      => "type-farm",
        _                => "type-default"
    };

    public string TypeIcon => AssetType switch
    {
        "ที่ดินเปล่า"    => "bi-map",
        "บ้านเดี่ยว"     => "bi-house-door",
        "ทาวน์เฮ้าส์"    => "bi-houses",
        "คอนโดมิเนียม"   => "bi-building",
        "อาคารพาณิชย์"   => "bi-shop",
        "โรงงาน"         => "bi-gear-fill",
        "สวน/ไร่นา"      => "bi-tree",
        _                => "bi-tag"
    };

    public string StatusText => Status switch
    {
        AssetStatus.Available => "ว่าง",
        AssetStatus.Reserved  => "จอง",
        AssetStatus.Sold      => "ขายแล้ว",
        _                     => "ไม่ทราบ"
    };

    public string StatusBadgeClass => Status switch
    {
        AssetStatus.Available => "badge-available",
        AssetStatus.Reserved  => "badge-reserved",
        AssetStatus.Sold      => "badge-sold",
        _                     => "badge-secondary"
    };

    public string AreaText
    {
        get
        {
            if (AssetType == "คอนโดมิเนียม") return $"{AreaWa:0.##} ตร.ม.";
            var parts = new List<string>();
            if (AreaRai > 0)  parts.Add($"{AreaRai:0.##} ไร่");
            if (AreaNgan > 0) parts.Add($"{AreaNgan:0.##} งาน");
            if (AreaWa > 0)   parts.Add($"{AreaWa:0.##} ตร.ว.");
            return parts.Count > 0 ? string.Join(" ", parts) : "-";
        }
    }
}

public enum AssetStatus
{
    Available = 0,
    Reserved  = 1,
    Sold      = 2
}
