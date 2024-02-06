using LeadTracker.API;
using LeadTracker.Core.Entities;

namespace LeadTracker.API;

public partial class VisitTracking : Identity
{
    public DateTime? StartDateTime { get; set; }

    public string StartLongitude { get; set; }

    public string StartLatitude { get; set; }

    public DateTime? StopDateTime { get; set; }

    public string StopLatitude { get; set; }

    public string StopLongitude { get; set; }

    public int? WorkFlowStepId { get; set; }

    public int? UserId { get; set; }

    public int? ProjectId { get; set; }

    public bool? Status { get; set; }


    public int? EnquiryId { get; set; }
    public string VisitStatus { get; set; }


    public virtual Lead Enquiry { get; set; }

    public virtual Project Project { get; set; }

    public virtual Employee User { get; set; }

    public virtual WorkFlowStep WorkFlowStep { get; set; }
}
