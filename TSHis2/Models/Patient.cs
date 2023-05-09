using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSHis2.Models;

public partial class Patient
{

    public int PatientId { get; set; }

    public string NationalId { get; set; } = null!;

    [Display(Name = "medical number")]
    public string Umn { get; set; } = null!;

    [Display(Name = "Name")]
    public string PatientName { get; set; } = null!;

    [Display(Name = "Age")]
    public int PatientAge { get; set; }

    [Display(Name = "Address")]
    public string PatientAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
