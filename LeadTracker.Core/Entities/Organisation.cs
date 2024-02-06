using LeadTracker.API.Entities;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Organisation : Identity
{

  

    public string? Name { get; set; }

  

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Code> Codes { get; set; } = new List<Code>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Holiday> Holidays { get; set; } = new List<Holiday>();

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<OrgAttendanceLocation> OrgAttendanceLocations { get; set; } = new List<OrgAttendanceLocation>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();

    public virtual ICollection<SystemConfiguration> SystemConfigurations { get; set; } = new List<SystemConfiguration>();

    public virtual ICollection<UserLocation> UserLocations { get; set; } = new List<UserLocation>();

    public virtual ICollection<WorkFlowDetail> WorkFlowDetails { get; set; } = new List<WorkFlowDetail>();

    public virtual ICollection<WorkFlowStep> WorkFlowSteps { get; set; } = new List<WorkFlowStep>();

    public virtual ICollection<WorkFlow> WorkFlows { get; set; } = new List<WorkFlow>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}

