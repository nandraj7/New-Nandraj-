using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class RolePermission : Identity
{
   

    public int? RoleId { get; set; }

    public int? PermissionId { get; set; }

    public int? OrgId { get; set; }

   

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
