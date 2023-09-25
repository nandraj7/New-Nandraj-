using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Organisation : Identity
{
   

    public string? Name { get; set; }

   

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Code> Codes { get; set; } = new List<Code>();

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

