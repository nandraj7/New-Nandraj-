using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class NextStepDTO
    {
          public int? WorkFlowStepId { get; set; }
          public int? WorkFlowId { get; set; }
          public string? NextStep { get; set; }

    }
}
