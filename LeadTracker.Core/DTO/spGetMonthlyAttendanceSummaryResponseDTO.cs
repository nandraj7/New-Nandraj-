using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetMonthlyAttendanceSummaryResponseDTO
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? Present { get; set; }
        public int? Absent { get; set; }
        public int? PendingApproval { get; set; }
    }
}
