using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public partial class NewBankDetailDTO
    {
        public IList<IFormFile> Files { get; set; }

        //public int? BankDetailId { get; set; }

        //public int? EmployeeId { get; set; }

        public string BankName { get; set; }

        public string Ifsccode { get; set; }

        public string AccountNo { get; set; }

        public string AadharCardNumber { get; set; }

        public string PancardNumber { get; set; }

        public string MobileNumber { get; set; }
    }
}
