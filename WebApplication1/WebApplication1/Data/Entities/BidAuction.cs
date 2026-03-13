using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class BidAuction
{
    public long Id { get; set; }

    public string PromotionId { get; set; } = null!;

    public string AssetId { get; set; } = null!;

    public decimal? StartPrice { get; set; }

    public decimal? BidPrice { get; set; }

    /// <summary>
    /// available, bidding, completed
    /// </summary>
    public string? BidStatus { get; set; }

    /// <summary>
    /// cust_key
    /// </summary>
    public string? BidWinner { get; set; }

    public string? ApproveStatusPrm { get; set; }

    public string? EditPriceFlgPrm { get; set; }

    public string? CancelFlgPrm { get; set; }

    public string? Reason { get; set; }

    public string? Committee1 { get; set; }

    public string? Committee2 { get; set; }

    public bool? IsPayment { get; set; }

    public DateTime? ContractDt { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? UpdateBy { get; set; }

    /// <summary>
    /// วันที่นัดทำสัญญา
    /// </summary>
    public DateTime? ContractCreateDt { get; set; }

    public string? ContractCreateBy { get; set; }
}
