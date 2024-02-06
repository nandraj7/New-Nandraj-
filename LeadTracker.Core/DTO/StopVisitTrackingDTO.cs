using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class StopVisitTrackingDTO
    {
        //public DateTime? StopDateTime { get; set; }
        public int? EnquiryId { get; set; }

        public string StopLatitude { get; set; }

        public string StopLongitude { get; set; }

    }
}
