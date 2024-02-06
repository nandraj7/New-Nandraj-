using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Dob { get; set; }

        public string Gender { get; set; }

        public string EmailId { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string ProfilePhoto { get; set; }

        public string DeviceId { get; set; }

        public string Password { get; set; }

        public string Mpin { get; set; }

        public int? OrgId { get; set; }

        public int? RoleId { get; set; }

        public int? ParentUserId { get; set; }

        public string AadharCardNumber { get; set; }

        public string PancardNumber { get; set; }

        public string Document { get; set; }

        public string EmployeeNumber { get; set; }

        public string Salary { get; set; }

        public string BioMatricCode { get; set; }

        public string Doj { get; set; }

        public string Reference { get; set; }

        public string Designation { get; set; }

        public string FatherNameOfEmployee { get; set; }

        public string AlternateNo { get; set; }

        public string CorrespondanceAddressDetails { get; set; }

        public string CorrespondancePlace { get; set; }

        public string CorrespondancePincode { get; set; }

        public string PermanentAdressDetails { get; set; }

        public string PermanentPlace { get; set; }

        public string PermanentPincode { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public string? RoleName { get; set; }
    }
}
