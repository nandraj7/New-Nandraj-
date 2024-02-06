using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;
public partial class AttendanceApproval : Identity
{
   

    public int? AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ApproveRequestId { get; set; }

    public string Status { get; set; }

    public DateTime? ApprovalDate { get; set; }


    public string? Remark { get; set; }

    public bool? IsStepCompleted { get; set; }


    public virtual Employee ApproveRequest { get; set; }

    public virtual Attendance Attendance { get; set; }

    public virtual Employee Employee { get; set; }
}
