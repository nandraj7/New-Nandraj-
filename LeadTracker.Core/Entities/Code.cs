using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Code : Identity
{
   

    public string? Type { get; set; }

    public string? CodesGroup { get; set; }

    public string? Value { get; set; }

   

    public int? OrgId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }
}
