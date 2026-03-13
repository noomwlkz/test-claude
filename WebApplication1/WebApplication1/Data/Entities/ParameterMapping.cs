using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class ParameterMapping
{
    public string? TypeCode { get; set; }

    public string? TypeDesc { get; set; }

    public string? ValueCode { get; set; }

    public string? ValueDesc { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? UpdateBy { get; set; }
}
