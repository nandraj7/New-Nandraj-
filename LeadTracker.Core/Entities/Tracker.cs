using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LeadTracker.API;

public partial class Tracker : Identity
{
   
    public int? EnquiryId { get; set; }

    public int? CodeId { get; set; }

    public string? Remark { get; set; }

    public DateTime? Date { get; set; }

    public bool? VisitExpected { get; set; }

    public DateTime? VisitExpectedDate { get; set; }

    public int? VisitedProjectId { get; set; }

    public string? VisitRemark { get; set; }

  
    public int? AssignedTo { get; set; }

    public int? WorkFlowId { get; set; }

    public int? WorkFlowStepId { get; set; }

    public string? Requirement { get; set; }

    public string? Budget { get; set; }

    public string? Purpose { get; set; }

    public string? PriorityStatus { get; set; }

    public bool? IsStepCompleted { get; set; }

    public decimal? CompanyPercentage { get; set; }

    public decimal? EmployeePercentage { get; set; }

    public decimal? TDS { get; set; }

    public decimal? RegistrationValue { get; set; }

    public decimal? TotalIncentive { get; set; }

    public int? OrgId { get; set; }

    [ForeignKey("EnquiryId")]
    public virtual Lead? Enquiry { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual WorkFlow? WorkFlow { get; set; }


    
    [JsonIgnore]
    public virtual WorkFlowStep? WorkFlowStep { get; set; }
    
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

   

    public virtual Project? VisitedProject { get; set; }

    
}
