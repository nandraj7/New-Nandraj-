using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class ProjectDetailDTO
    {
        public int ProjectDetailsId { get; set; }

        public int? ProjectId { get; set; }

        public string? Wing { get; set; }

        public string? Floor { get; set; }

        public string? Unit { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

       
    }
}
