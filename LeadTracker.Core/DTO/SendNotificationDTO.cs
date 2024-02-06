using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class SendNotificationDTO
    {
        public List<int?> UserId { get; set; }
        public string NotificationText { get; set; }
    }

}
