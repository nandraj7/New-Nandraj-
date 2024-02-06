using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spStepCountDTO
    {
        public int Id { get; set; }
        public string StepName { get; set; }

        public int StepCount { get; set; }

        public int StepCountIsFalse { get; set; }

        public int? HotCount { get; set; }

        public int? WarmCount { get; set; }

        public int? ColdCount { get; set; }
    }
}
