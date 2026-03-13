using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class Payment
{
    public string RowId { get; set; } = null!;

    public string? AccntInfoId { get; set; }

    public string? CustomerName { get; set; }

    public string? BranchName { get; set; }

    public string? ReceiptNo { get; set; }

    public DateTime? PaymentDt { get; set; }

    public decimal? Amount { get; set; }

    public string? AmountTxt { get; set; }

    public string? ChequeNo { get; set; }

    public string? BankAndBranch { get; set; }

    public DateTime? ChequeDt { get; set; }

    public string? MethodCode { get; set; }

    public DateTime? CancelDt { get; set; }

    public string? Canceller { get; set; }

    public string? StatusLv { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastUpdBy { get; set; }

    public DateTime? LastUpd { get; set; }
}
