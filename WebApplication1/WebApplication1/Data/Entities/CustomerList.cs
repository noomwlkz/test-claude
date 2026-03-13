using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class CustomerList
{
    public string CustKey { get; set; } = null!;

    public string? Ssn { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Address { get; set; }

    public string? TelNum { get; set; }

    public string? AuthorizedPerson { get; set; }

    /// <summary>
    /// T - ThaID, 
    /// M - Manual, 
    /// S - Scan ID Card
    /// </summary>
    public string? AuthFlag { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    /// <summary>
    /// IND - ประมูลเอง (Individual), 
    /// AGT - ผู้รับมอบอำนาจ (Agent), 
    /// COM - ประมูลในนามบริษัท (Company)
    /// </summary>
    public string? AuthType { get; set; }

    public bool? IsVerify { get; set; }
}
