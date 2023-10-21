using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class ProjectDetail : Identity
{


    public int? ProjectId { get; set; }

    public string? Wing { get; set; }

    public string? Floor { get; set; }

    public string? Unit { get; set; }

   

    public virtual Project? Project { get; set; }
}
