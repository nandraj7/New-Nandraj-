using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class RolePermission : Identity
{


    public int? RoleId { get; set; }

    public int? PermissionId { get; set; }

    public int? OrgId { get; set; }

   

    public virtual Organisation? Org { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
