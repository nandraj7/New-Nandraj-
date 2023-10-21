using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Document : Identity
{
   

    public int? EnquiryId { get; set; }

    public int? TrackerId { get; set; }

    public int? ModuleType { get; set; }

    public string? Location { get; set; }

    public int? UserId { get; set; }

    public int? OrgId { get; set; }

    public string? Comment { get; set; }

    public int? WorkFlowId { get; set; }

    public int? WorkFlowStepId { get; set; }

   

    public virtual Lead? Enquiry { get; set; }

    public virtual Code? ModuleTypeNavigation { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual Tracker? Tracker { get; set; }

    public virtual Employee? User { get; set; }

    public virtual WorkFlow? WorkFlow { get; set; }

    public virtual WorkFlowStep? WorkFlowStep { get; set; }
}
