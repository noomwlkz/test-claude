using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class ControlDate
{
    public string? PromotionId { get; set; }

    public DateTime? AuctionStart { get; set; }

    public DateTime? AuctionEnd { get; set; }

    public string? AuctionName { get; set; }

    public string? UrlConsent { get; set; }

    public string? BackgroundImgUrl { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastUpd { get; set; }

    public string? LastUpdBy { get; set; }

    public string? ImgId { get; set; }

    public string? CongratsImgUrl { get; set; }

    public DateTime? ContractStartDt { get; set; }

    public DateTime? ContractEndDt { get; set; }
}
