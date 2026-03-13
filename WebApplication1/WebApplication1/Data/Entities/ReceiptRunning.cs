using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class ReceiptRunning
{
    public string RowId { get; set; } = null!;

    public string? DivCode { get; set; }

    public string? ReferenceType { get; set; }

    public int? YearVal { get; set; }

    public string? Runno { get; set; }

    public string? StatusLv { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastUpd { get; set; }

    public string? LastUpdBy { get; set; }
}
