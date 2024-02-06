using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    [Keyless]
    public class spAddAbsentRemarkDTO
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Remark { get; set; }

    }
}
