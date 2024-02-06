using LeadTracker.API.Entities;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LeadTracker.API;


public partial class Employee : Identity
{
    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Mpin { get; set; }

    public string? Mobile { get; set; }

    public int? ParentUserId { get; set; }

    public string Dob { get; set; }

   // public string Address { get; set; }

    public int? OrgId { get; set; }

    public string? Gender { get; set; }

    public int? RoleId { get; set; }

    public string? ProfilePhoto { get; set; }

    public string? DeviceId { get; set; }

    public string Document { get; set; }

    public string AadharCardNumber { get; set; }

    public string PancardNumber { get; set; }

    public string EmployeeNumber { get; set; }

    public string Salary { get; set; }

    public string BioMatricCode { get; set; }

    public string Doj { get; set; }

    public string Reference { get; set; }

    public string Designation { get; set; }

    public string FatherNameOfEmployee { get; set; }

    public string AlternateNo { get; set; }

    public string CorrespondanceAddressDetails { get; set; }

    public string CorrespondancePlace { get; set; }

    public string CorrespondancePincode { get; set; }

    public string PermanentAdressDetails { get; set; }

    public string PermanentPlace { get; set; }

    public string PermanentPincode { get; set; }

    public virtual ICollection<AttendanceApproval> AttendanceApprovalApproveRequests { get; set; } = new List<AttendanceApproval>();

    public virtual ICollection<AttendanceApproval> AttendanceApprovalEmployees { get; set; } = new List<AttendanceApproval>();
    public virtual ICollection<BankDetail> BankDetails { get; set; } = new List<BankDetail>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    [JsonIgnore]
    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    [JsonIgnore]
    public virtual ICollection<Notification> NotificationParentUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationUsers { get; set; } = new List<Notification>();


    public virtual ICollection<Attendance> AttendanceApprovedByNavigations { get; set; } = new List<Attendance>();

    public virtual ICollection<Attendance> AttendanceUsers { get; set; } = new List<Attendance>();

    public virtual Organisation? Org { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserLocation> UserLocations { get; set; } = new List<UserLocation>();

    public virtual ICollection<VisitTracking> VisitTrackings { get; set; } = new List<VisitTracking>();

}

