using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class EnquiryDTO
    {
        public LeadDTO Lead { get; set; }

        public List<TrackerDTO> Trackers { get; set; }

    }
}
