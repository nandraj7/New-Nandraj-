using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class HolidayDTO
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public string? Day { get; set; }

        public string? HolidayReason { get; set; }

        public int? OrgId { get; set; }

        public bool? Status { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }

}
