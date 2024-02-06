using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class NewEducationDTO
    {
        public IList<IFormFile> Files { get; set; }

        //public int? EducationId { get; set; }

        //public int? EmployeeId { get; set; }

        public string Sscpercentage { get; set; }

        public string SscyearOfPassing { get; set; }

        public string Hscpercentage { get; set; }

        public string HscyearOfPassing { get; set; }

        public string GraduationType { get; set; }

        public string GraduationPercentage { get; set; }

        public string GraduationYearOfPassing { get; set; }
    }
}
