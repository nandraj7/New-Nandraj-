﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class ReAssignDTO
    {
        public int AssignedTo { get; set; }
        public List<int> TrackerId { get; set; }
    }
}
