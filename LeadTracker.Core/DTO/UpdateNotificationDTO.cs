using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class UpdateNotificationDTO
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
    }

}
