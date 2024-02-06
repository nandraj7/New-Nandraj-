using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class LeadDTO
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? LeadSource { get; set; }

        public string? LeadSourceProject { get; set; }

        public string? Name { get; set; }

        public string? MobNo { get; set; }

        public string? EmailId { get; set; }

        public string? Requirement { get; set; }

        public string? Budget { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public string? FinalRemark { get; set; }

        public string? EnquiryType { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? TrackerFlowStepId { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? OrgId { get; set; }

        public string? Purpose { get; set; }



    }
}
