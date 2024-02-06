using System;
using System.Collections.Generic;

namespace LeadTracker.API.LeadTracker.API.SQL;

public partial class OrgAttendanceLocation
{
    public int OrgLocationId { get; set; }

    public int? OrgId { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public virtual Organisation Org { get; set; }
}
