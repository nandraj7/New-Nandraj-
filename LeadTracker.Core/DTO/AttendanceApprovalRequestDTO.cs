﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class AttendanceApprovalRequestDTO
    {
        public List<int> UserIds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Status { get; set; }
        public string? Remark { get; set; }

    }
}
