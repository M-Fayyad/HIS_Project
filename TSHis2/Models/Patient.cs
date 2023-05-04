using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string NationalId { get; set; } = null!;

    public string Umn { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public int PatientAge { get; set; }

    public string PatientAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
