using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Branch : Identity
{
    
    public string? Name { get; set; }

 

    public int? ParentBranchId { get; set; }

    public int? OrgId { get; set; }

    public int? CodeId { get; set; }

   

    public virtual Code? Code { get; set; }

    public virtual Organisation? Org { get; set; }
}
