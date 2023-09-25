using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class CodeService : ICodeService
    {
        private readonly ICodeRepository _coderepository;
        private readonly IMapper _mappingProfile;

        public CodeService(IMapper mappingProfile, ICodeRepository codeService)
        {
            _mappingProfile = mappingProfile;
            _coderepository = codeService;

        }

        public async Task CreateCode(CodeDTO code)
        {
            var cod = _mappingProfile.Map<Code>(code);
            await _coderepository.CreateAsync(cod).ConfigureAwait(false);
        }

        public async Task<Code> GetCodeByIdAsync(int id)
        {
            return await _coderepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Code>> GetAllCodeAsync()
        {
            var codes = await _coderepository.GetAllAsync();
            return codes.ToList();
        }

        public async Task UpdateCodeAsync(CodeDTO code)
        {
            var cd = _mappingProfile.Map<Code>(code);
            await _coderepository.UpdateAsync(cd);
        }

        public async Task DeleteCodeAsync(int id)
        {
            var code = await _coderepository.GetByIdAsync(id);
            if (code != null)
            {
                await _coderepository.DeleteAsync(id);
            }
        }

    }
}
