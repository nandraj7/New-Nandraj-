using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class EmployeeRole
{
    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public int? OrgId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

 

    public DateTime? CreatedDate { get; set; }


    public DateTime? ModifiedDate { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Employee? User { get; set; }
}
