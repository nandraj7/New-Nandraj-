using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class UserLocationDTO
    {
        //public int UserLocationId { get; set; }

        //public int? UserId { get; set; }

        //public DateTime? Date { get; set; }

        [JsonRequired]
        public string? CurrentLatitude { get; set; }

        [JsonRequired]
        public string? CurrentLongitude { get; set; }

        //public string? StartLatitude { get; set; }

        //public string? StartLongitude { get; set; }

        //public int? OrgId { get; set; }
    }
}
