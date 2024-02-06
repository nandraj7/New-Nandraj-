using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetEmployeeBookingSummaryResponseDTO
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public int? Booking { get; set; }

    }
}
