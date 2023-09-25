using System;
using System.Collections.Generic;

namespace LeadTracker.Core.Entities;

public partial class Address : Identity
{
   

    public string? AddressDetails { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public int? CodeId { get; set; }

    public int? UnitId { get; set; }

    public virtual Code? Code { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? ModifiedByNavigation { get; set; }
}
