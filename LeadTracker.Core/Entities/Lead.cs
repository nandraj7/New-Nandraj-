﻿using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LeadTracker.API;

public partial class Lead : Identity
{



    public DateTime? Date { get; set; }

    public string? LeadSource { get; set; }

    public string? LeadSourceProject { get; set; }

    public string? Name { get; set; }

    public string? MobNo { get; set; }

    public string? EmailId { get; set; }

    public string? Requirement { get; set; }

    public string? Budget { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public string? FinalRemark { get; set; }

    public string? EnquiryType { get; set; }

    public string Purpose { get; set; }

    public int? TrackerFlowStepId { get; set; }

    public int? AssignedTo { get; set; }

   

   

    public int? OrgId { get; set; }
    [JsonIgnore]
    public virtual Employee? AssignedToNavigation { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Organisation? Org { get; set; }
    [JsonIgnore]
    public virtual WorkFlowStep? TrackerFlowStep { get; set; }
    public virtual ICollection<VisitTracking> VisitTrackings { get; set; } = new List<VisitTracking>();


}

