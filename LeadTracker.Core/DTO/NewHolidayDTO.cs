using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class NewHolidayDTO
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public string? Day { get; set; }

        public string? HolidayReason { get; set; }
    }
}
