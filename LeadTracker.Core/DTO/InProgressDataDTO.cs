using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class InProgressDataDTO
    {
        public List<spParentDTO> ParentFlow { get; set; }

        public List<InProgressAttendances> Attendance { get; set; }
    }
}
