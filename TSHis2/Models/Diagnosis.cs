using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSHis2.Models;

public partial class Diagnosis
{
    public int DiagnosisId { get; set; }

    public int? VisitId { get; set; }

    public string? Examiation { get; set; }

    public string? Drugs { get; set; }

    public string? Tests { get; set; }

    [Display(Name = "Diagnosis")]
    public string? Diagnosis1 { get; set; }

    public string? DoctorDecision { get; set; }

    public DateTime DiagnosisDate { get; set; } = DateTime.Now;

    public string? DiagnosisLocation { get; set; }

    public virtual ICollection<DiagnosisDrug> DiagnosisDrugs { get; set; } = new List<DiagnosisDrug>();

    public virtual ICollection<DiagnosisTest> DiagnosisTests { get; set; } = new List<DiagnosisTest>();

    public virtual Visit? Visit { get; set; }
}
