using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class InProgressAttendances
    {
        public int ApprovalId { get; set; }

        public int? AttendanceId { get; set; }

        public int? EmployeeId { get; set; }

        public int? ApproveRequestId { get; set; }

        public string Status { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsStepCompleted { get; set; }

        public string? Remark { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? EmployeeName { get; set; }
    }
}
