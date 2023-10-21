using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class DocumentDTO
    {
        public IList<IFormFile> Files { get; set; }
        //public int DocumentId { get; set; }

        public int? EnquiryId { get; set; }

        public int? TrackerId { get; set; }

        public int? ModuleType { get; set; }

        //public string? Location { get; set; }

        //public int? UserId { get; set; }

        //public int? OrgId { get; set; }

        public string? Comment { get; set; }

        public int? WorkFlowId { get; set; }

        public int? WorkFlowStepId { get; set; }

        //public bool? IsActive { get; set; }

        //public bool? IsDeleted { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public DateTime? ModifiedDate { get; set; }

        //public int? CreatedBy { get; set; }

        //public int? ModifiedBy { get; set; }

    }
}
