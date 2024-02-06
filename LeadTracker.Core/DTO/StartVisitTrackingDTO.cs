using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class StartVisitTrackingDTO
    {
        //public DateTime? StartDateTime { get; set; }

        public string StartLongitude { get; set; }

        public string StartLatitude { get; set; }

        public int? ProjectId { get; set; }

        public int? EnquiryId { get; set; }


    }
}
