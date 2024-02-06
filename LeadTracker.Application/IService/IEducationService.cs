using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IEducationService
    {
        //Task RegisterEmployeeEducation(NewEducationDTO education, int userId);
        //Task RegisterEmployeeBankDetail(NewBankDetailDTO bankDetail, int userId);

        Task<EducationDTO> UpdateEmployeeEducation(int employeeId, NewEducationDTO education, int userId);
        Task<BankDetailDTO> UpdateEmployeeBankDetail(int employeeId, NewBankDetailDTO bankDetail, int userId);

    }
}
