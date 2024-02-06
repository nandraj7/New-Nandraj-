using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;
public partial class SystemConfiguration
{
    public int ConfigId { get; set; }

    public int? OrgId { get; set; }

    public string KeyDetail { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }

    public virtual Organisation Org { get; set; }
}
