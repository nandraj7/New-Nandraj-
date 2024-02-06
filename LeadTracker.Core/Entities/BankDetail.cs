using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class BankDetail : Identity
{
    public int? EmployeeId { get; set; }

    public string BankName { get; set; }

    public string Ifsccode { get; set; }

    public string AccountNo { get; set; }

    public string AadharCardNumber { get; set; }

    public string PancardNumber { get; set; }

    public string MobileNumber { get; set; }

    public string Document { get; set; }

    public virtual Employee Employee { get; set; }
}
