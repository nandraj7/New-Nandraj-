using LeadTracker.API;
using LeadTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class EmployeeDetailsDTO
    {
        public EmployeeDTO Employees { get; set; }
        public EducationDTO Educations { get; set; }
        public BankDetailDTO BankDetails { get; set; }
    }
}
