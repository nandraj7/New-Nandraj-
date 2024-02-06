using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class BankDetailDTO
    {
        //public int? BankDetailId { get; set; }

        public int? EmployeeId { get; set; }

        public string BankName { get; set; }

        public string Ifsccode { get; set; }

        public string AccountNo { get; set; }

        public string AadharCardNumber { get; set; }

        public string PancardNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Document { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
