using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpSsn { get; set; } = null!;

    public string EmpName { get; set; } = null!;

    public int? Gender { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? JobTitle { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
}
