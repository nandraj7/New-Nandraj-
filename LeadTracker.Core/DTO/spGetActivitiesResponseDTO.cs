using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetActivitiesResponseDTO
    {
        public int TrackerId { get; set; }
        public int? EnquiryId { get; set; }
        public int? CodeId { get; set; }
        public string? Remark { get; set; }
        public DateTime? Date { get; set; }
        public bool? VisitExpected { get; set; }
        public DateTime? VisitExpectedDate { get; set; }
        public int? VisitedProjectId { get; set; }
        public string? VisitRemark { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? AssignedTo { get; set; }
        public int? WorkFlowId { get; set; }
        public int? WorkFlowStepId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsStepCompleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? OrgId { get; set; }
        public string? PriorityStatus { get; set; }
        public string? Requirement { get; set; }
        public string? Budget { get; set; }
        public string? Purpose { get; set; }
        public string? LeadSource { get; set; }
        public string? LeadSourceProject { get; set; }
        public string? LeadName { get; set; }
        public string? LeadMobNo { get; set; }
        public string? LeadEmail { get; set; }
        public string? LeadRequirement { get; set; }
        public string? LeadBudget { get; set; }
        public string? LeadDescription { get; set; }
        public long? RowNum { get; set; }
        public decimal? CompanyPercentage { get; set; }
        public decimal? EmployeePercentage { get; set; }
        public decimal? RegistrationValue { get; set; }
        public decimal? TotalIncentive { get; set; }
        public decimal? TDS { get; set; }
    }

}
