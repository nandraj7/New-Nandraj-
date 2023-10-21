using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class TokenDTO
    {
        public EmployeeDTO User { get; set; }

        public string Token { get;set; }
    }
}
