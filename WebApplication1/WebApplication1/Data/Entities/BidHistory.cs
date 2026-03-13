using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class BidHistory
{
    public long Id { get; set; }

    public long? AuctionId { get; set; }

    public string? PromotionId { get; set; }

    public string? AssetId { get; set; }

    public decimal? BidPrice { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? UpdateBy { get; set; }

    /// <summary>
    /// plus, manual
    /// </summary>
    public string? ActionLv { get; set; }
}
