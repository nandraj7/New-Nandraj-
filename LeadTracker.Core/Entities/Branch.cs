using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Branch : Identity
{
   

    public string? Name { get; set; }

   

    public int? ParentBranchId { get; set; }

   

    public int? OrgId { get; set; }

    public int? CodeId { get; set; }

    public virtual Code? Code { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }
}

