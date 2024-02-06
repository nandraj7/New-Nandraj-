using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spEnquiryDTO
    {
        //[Key]
        public int EnquiryId { get; set; }
        public DateTime Date { get; set; }
        public string LeadSource { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Requirement { get; set; }
        public string Budget { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int TrackerFlowId { get; set; }
    }
}
