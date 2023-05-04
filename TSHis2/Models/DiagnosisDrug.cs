using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class DiagnosisDrug
{
    public int Id { get; set; }

    public int? DiagnosisId { get; set; }

    public int? DrugId { get; set; }

    public virtual Diagnosis? Diagnosis { get; set; }

    public virtual Drug? DiagnosisNavigation { get; set; }
}
