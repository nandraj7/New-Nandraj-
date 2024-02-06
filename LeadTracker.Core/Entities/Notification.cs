using LeadTracker.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeadTracker.Core.Entities
{
    public partial class Notification : Identity
    {
        public int? UserId { get; set; }

        public string NotificationText { get; set; }

        public string ModuleName { get; set; }

        public string Status { get; set; }

        public int? ParentUserId { get; set; }

        public virtual Employee ParentUser { get; set; }


        [JsonIgnore]
        public virtual Employee User { get; set; }
    }
}
