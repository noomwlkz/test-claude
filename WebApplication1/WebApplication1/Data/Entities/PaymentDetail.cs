using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class PaymentDetail
{
    public string RowId { get; set; } = null!;

    public string? PaymentId { get; set; }

    public string AssetId { get; set; } = null!;

    public string? AssetNo { get; set; }

    public string? AssetNum { get; set; }

    public int? SeqNo { get; set; }

    public string? ItemCode { get; set; }

    public string? ItemName { get; set; }

    public decimal? Amount { get; set; }

    public decimal? BidPrice { get; set; }

    public string? StatusLv { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastUpdBy { get; set; }

    public DateTime? LastUpd { get; set; }
}
