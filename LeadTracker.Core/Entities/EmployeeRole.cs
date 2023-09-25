using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class EmployeeRole : Identity
{
    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public int? OrgId { get; set; }

   

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Employee? User { get; set; }
}
