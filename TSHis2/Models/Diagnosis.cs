using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class Diagnosis
{
    public int DiagnosisId { get; set; }

    public int? VisitId { get; set; }

    public int? EmpId { get; set; }

    public string? Examiation { get; set; }

    public string? Diagnosis1 { get; set; }

    public string? DoctorDecision { get; set; }

    public DateTime? DiagnosisDate { get; set; }

    public TimeSpan? DiagnosisHour { get; set; }

    public string? DiagnosisLocation { get; set; }

    public virtual ICollection<DiagnosisDrug> DiagnosisDrugs { get; set; } = new List<DiagnosisDrug>();

    public virtual ICollection<DiagnosisTest> DiagnosisTests { get; set; } = new List<DiagnosisTest>();

    public virtual Employee? Emp { get; set; }

    public virtual Visit? Visit { get; set; }
}
