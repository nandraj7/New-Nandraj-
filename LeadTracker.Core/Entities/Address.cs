using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Address : Identity
{
   

    public string? AddressDetails { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

   

    public int? UnitId { get; set; }

    public int? CodeId { get; set; }

    

    public virtual Code? Code { get; set; }
}
