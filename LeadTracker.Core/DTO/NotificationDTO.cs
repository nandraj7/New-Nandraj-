using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class NotificationDTO
    {
        public int? NotificationId { get; set; }

        public int? UserId { get; set; }

        public string NotificationText { get; set; }

        public string ModuleName { get; set; }

        public string Status { get; set; }

        public int? ParentUserId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }

}
