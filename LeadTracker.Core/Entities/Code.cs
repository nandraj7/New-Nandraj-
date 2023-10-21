using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Code : Identity
{

    public string? Type { get; set; }

    public string? CodesGroup { get; set; }

    public string? Value { get; set; }

   

    public int? OrgId { get; set; }

    

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
