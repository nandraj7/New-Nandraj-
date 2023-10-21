using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;


public partial class WorkFlowStep : Identity
{
    public int? WorkFlowId { get; set; }

    public string? PreviousStep { get; set; }

    public string? CurrentStep { get; set; }

    public string? NextStep { get; set; }



    public int? OrgId { get; set; }



    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();

    public virtual WorkFlow? WorkFlow { get; set; }


    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

}
