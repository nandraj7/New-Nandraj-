using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class StatusDTO
    {
        public IList<IFormFile>? Files { get; set; }

        public int? EnquiryId { get; set; }

        public int? TrackerId { get; set; }

        public string? Name { get; set; }

        public int? ModuleType { get; set; }



        public DateTime? VisitExpectedDate { get; set; }

        public int? VisitedProjectId { get; set; }

        public string? PriorityStatus { get; set; }

        public string? Requirement { get; set; }

        public string? Budget { get; set; }

        public string? Comment { get; set; }

        public int? WorkFlowId { get; set; }

        public int? CurrentWorkFlowStepId { get; set; }

        public int? NextWorkFlowStepId { get; set; }

        public string? Purpose { get; set; }

        public decimal? CompanyPercentage { get; set; }
        public decimal? EmployeePercentage { get; set; }
        public decimal? RegistrationValue { get; set; }
        public decimal? TotalIncentive { get; set; }
        public decimal? TDS { get; set; }


    }
}
