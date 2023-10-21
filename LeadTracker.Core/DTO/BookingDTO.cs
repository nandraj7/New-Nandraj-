using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }

        public int? EnquiryId { get; set; }

        public DateTime? BookingDate { get; set; }

        public string? ClientName { get; set; }

        public string? ClientPhone { get; set; }

        public string? ClientEmail { get; set; }

        public int? ProjectId { get; set; }

        public string? Wing { get; set; }

        public int? UnitId { get; set; }

        public decimal? AgreementCost { get; set; }

        public string? BrokerageSlab { get; set; }

        public string? AssignedTo { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

    
    }
}
