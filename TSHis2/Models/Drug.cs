using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class Drug
{
    public int DrugId { get; set; }

    public int TreatmentId { get; set; }

    public string? GenericName { get; set; }

    public string? Concentration { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<DiagnosisDrug> DiagnosisDrugs { get; set; } = new List<DiagnosisDrug>();
}
