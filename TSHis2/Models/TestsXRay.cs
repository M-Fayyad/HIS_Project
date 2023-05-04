using System;
using System.Collections.Generic;

namespace TSHis2.Models;

public partial class TestsXRay
{
    public int TestId { get; set; }

    public string? TestName { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<DiagnosisTest> DiagnosisTests { get; set; } = new List<DiagnosisTest>();
}
