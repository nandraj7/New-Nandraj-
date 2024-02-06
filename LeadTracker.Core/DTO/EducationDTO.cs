using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class EducationDTO
    {
        //public int? EducationId { get; set; }

        public int? EmployeeId { get; set; }

        public string Sscpercentage { get; set; }

        public string SscyearOfPassing { get; set; }

        public string Hscpercentage { get; set; }

        public string HscyearOfPassing { get; set; }

        public string GraduationType { get; set; }

        public string GraduationPercentage { get; set; }

        public string GraduationYearOfPassing { get; set; }

        public string Document { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
