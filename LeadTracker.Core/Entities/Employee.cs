using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Employee : Identity
{

    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Mpin { get; set; }

    public string? Mobile { get; set; }

    public int? ParentUserId { get; set; }

  

    public int? OrgId { get; set; }

   
    public virtual ICollection<Address> AddressCreatedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressModifiedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Branch> BranchCreatedByNavigations { get; set; } = new List<Branch>();

    public virtual ICollection<Branch> BranchModifiedByNavigations { get; set; } = new List<Branch>();

    public virtual ICollection<Code> CodeCreatedByNavigations { get; set; } = new List<Code>();

    public virtual ICollection<Code> CodeModifiedByNavigations { get; set; } = new List<Code>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<Organisation> OrganisationCreatedByNavigations { get; set; } = new List<Organisation>();

    public virtual ICollection<Organisation> OrganisationModifiedByNavigations { get; set; } = new List<Organisation>();

    public virtual ICollection<Permission> PermissionCreatedByNavigations { get; set; } = new List<Permission>();

    public virtual ICollection<Permission> PermissionModifiedByNavigations { get; set; } = new List<Permission>();

    public virtual ICollection<Role> RoleCreatedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<Role> RoleModifiedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<RolePermission> RolePermissionCreatedByNavigations { get; set; } = new List<RolePermission>();

    public virtual ICollection<RolePermission> RolePermissionModifiedByNavigations { get; set; } = new List<RolePermission>();
}
