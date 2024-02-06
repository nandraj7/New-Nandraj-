using LeadTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTracker.API.Entities;

public partial class Education : Identity
{
    
    public int? EmployeeId { get; set; }

    public string Sscpercentage { get; set; }

    public string SscyearOfPassing { get; set; }

    public string Hscpercentage { get; set; }

    public string HscyearOfPassing { get; set; }

    public string GraduationType { get; set; }

    public string GraduationPercentage { get; set; }

    public string GraduationYearOfPassing { get; set; }

    public string Document { get; set; }

    public virtual Employee? Employee { get; set; }
}
