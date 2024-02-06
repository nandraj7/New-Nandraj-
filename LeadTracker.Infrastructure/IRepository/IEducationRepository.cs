using LeadTracker.API;
using LeadTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IEducationRepository : IRepository<Education>
    {
        //Task RegisterEmployeeEducationAsync(List<Education> education);
        //Task RegisterEmployeeBankDetailAsync(List<BankDetail> bankDetail);
        Task<Education> GetEducationByEmployeeIdAsync(int employeeId);
        Task UpdateEducationAsync(Education education);

        Task<BankDetail> GetBankDetailByEmployeeIdAsync(int employeeId);
        Task UpdateBankDetailAsync(BankDetail bankDetail);
    }
}
