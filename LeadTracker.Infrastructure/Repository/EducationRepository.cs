using LeadTracker.API;
using LeadTracker.API.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        private readonly LeadTrackerContext _context;

        public EducationRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }


        //public async Task RegisterEmployeeEducationAsync(List<Education> education)
        //{
        //    foreach (var entity in education)
        //    {
        //        entity.IsActive = true;
        //        entity.CreatedDate = DateTime.Now;
        //        entity.ModifiedDate = DateTime.Now;
        //        entity.IsDeleted = false;

        //        await (_context as LeadTrackerContext).Educations.AddAsync(entity).ConfigureAwait(false);
        //    }
        //    await _context.SaveChangesAsync().ConfigureAwait(false);
        //}

        //public async Task RegisterEmployeeBankDetailAsync(List<BankDetail> bankDetail)
        //{
        //    foreach (var entity in bankDetail)
        //    {
        //        entity.IsActive = true;
        //        entity.CreatedDate = DateTime.Now;
        //        entity.ModifiedDate = DateTime.Now;
        //        entity.IsDeleted = false;

        //        await (_context as LeadTrackerContext).BankDetails.AddAsync(entity).ConfigureAwait(false);
        //    }
        //    await _context.SaveChangesAsync().ConfigureAwait(false);
        //}

        public async Task<Education> GetEducationByEmployeeIdAsync(int employeeId)
        {
            return await _context.Educations
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                .ConfigureAwait(false);
        }
        public async Task UpdateEducationAsync(Education education)
        {
            //_context.Educations.Update(education);
            //await _context.SaveChangesAsync().ConfigureAwait(false);
            _context.Entry(education).State = EntityState.Modified;

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }


        public async Task<BankDetail> GetBankDetailByEmployeeIdAsync(int employeeId)
        {
            return await _context.BankDetails
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                .ConfigureAwait(false); ;
        }

        public async Task UpdateBankDetailAsync(BankDetail bankDetail)
        {
            _context.BankDetails.Update(bankDetail);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
