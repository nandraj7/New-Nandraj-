using LeadTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTracker.API.Entities;

public partial class Holiday : Identity
{
    public DateTime? Date { get; set; }

    public string Day { get; set; }

    public string HolidayReason { get; set; }

    public int? OrgId { get; set; }

    public bool? Status { get; set; }

    public virtual Organisation Org { get; set; }
}
