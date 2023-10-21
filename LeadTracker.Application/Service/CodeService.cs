using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<CodeDTO> GetCodeByIdAsync(int id)
        {

            var code = await _coderepository.GetByIdAsync(id);

            var codeDTO = _mappingProfile.Map<CodeDTO>(code);
            return codeDTO;
        }

        public async Task<IEnumerable<CodeDTO>> GetAllCodeAsync()
        {
            var codes = await _coderepository.GetAllAsync();
            var codesDTO = _mappingProfile.Map<List<CodeDTO>>(codes);
            return codesDTO.ToList();
        }

        public async Task UpdateCodeAsync(int id, CodeDTO code)
        {
            var existingCode = await _coderepository.GetByIdAsync(id);


            _mappingProfile.Map(code, existingCode);


            await _coderepository.UpdateAsync(existingCode);

            //var cd = _mappingProfile.Map<Code>(code);
            //await _coderepository.UpdateAsync(cd);
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
