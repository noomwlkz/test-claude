using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class AssetMaster
{
    public string? AssetNo { get; set; }

    public string AssetId { get; set; } = null!;

    public string? AssetNum { get; set; }

    public string? AssetType { get; set; }

    public string? AssetName { get; set; }

    public string? Size { get; set; }

    public string? Price { get; set; }

    public string? Tel { get; set; }

    public string? HouseNo { get; set; }

    public string? Road { get; set; }

    public string? Soi { get; set; }

    public string? Floor { get; set; }

    public string? FloorNo { get; set; }

    public string? Subdistrict { get; set; }

    public string? District { get; set; }

    public string? Province { get; set; }

    public string? DeedNo { get; set; }

    public string? StatusFlg { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastUpd { get; set; }

    public string? LastUpdBy { get; set; }

    public string? SubdistrictCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? ProvinceCode { get; set; }

    public string? ImgUrl { get; set; }

    public string? BeforeStatusFlg { get; set; }

    public string? AddressFulltext { get; set; }

    public string? Moo { get; set; }
}
