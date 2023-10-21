using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Permission : Identity
{
   

    public string? Name { get; set; }

   

    public int? OrgId { get; set; }

   

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
