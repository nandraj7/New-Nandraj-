using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Zone : Identity
{ 

    public string? ZoneName { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
