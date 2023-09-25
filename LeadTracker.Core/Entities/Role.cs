using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Role : Identity
{
    

    public string? Name { get; set; }

  

    public int? OrgId { get; set; }

  

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
