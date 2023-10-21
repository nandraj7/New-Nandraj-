using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Booking : Identity
{
  

    public int? EnquiryId { get; set; }

    public DateTime? BookingDate { get; set; }

    public string? ClientName { get; set; }

    public string? ClientPhone { get; set; }

    public string? ClientEmail { get; set; }

    public int? ProjectId { get; set; }

    public string? Wing { get; set; }

    public int? UnitId { get; set; }

    public decimal? AgreementCost { get; set; }

    public string? BrokerageSlab { get; set; }

    public string? AssignedTo { get; set; }

  

    public virtual Lead? Enquiry { get; set; }

    public virtual Project? Project { get; set; }
}
