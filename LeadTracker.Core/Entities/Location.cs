using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Location : Identity
{
   

    public string? LocationName { get; set; }

    public int? ZoneId { get; set; }

   

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Zone? Zone { get; set; }
}
