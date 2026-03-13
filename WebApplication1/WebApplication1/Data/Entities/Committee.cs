using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class Committee
{
    public string RowId { get; set; } = null!;

    public string? EmpCode { get; set; }

    public string? EmpName { get; set; }

    public string? StatusValue { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? UpdateBy { get; set; }
}
