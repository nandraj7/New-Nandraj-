using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class VisitTrackingDTO
    {
        public int VisitTrackingId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public string StartLongitude { get; set; }

        public string StartLatitude { get; set; }

        public DateTime? StopDateTime { get; set; }

        public string StopLatitude { get; set; }

        public string StopLongitude { get; set; }

        public int? WorkFlowStepId { get; set; }

        public int? UserId { get; set; }

        public int? ProjectId { get; set; }

        public bool? Status { get; set; }

        public int? EnquiryId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
