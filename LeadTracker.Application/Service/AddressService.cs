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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressrepository;
        private readonly IMapper _mappingProfile;

        public AddressService(IMapper mappingProfile, IAddressRepository addressService)
        {
            _mappingProfile = mappingProfile;
            _addressrepository = addressService;

        }

        public async Task CreateAddress(AddressDTO address)
        {
            var adr = _mappingProfile.Map<Address>(address);
            await _addressrepository.CreateAsync(adr).ConfigureAwait(false);
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressrepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            var addresses = await _addressrepository.GetAllAsync();
            return addresses.ToList();
        }

        public async Task UpdateAddressAsync(AddressDTO address)
        {
            var adr = _mappingProfile.Map<Address>(address);
            await _addressrepository.UpdateAsync(adr);
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _addressrepository.GetByIdAsync(id);
            if (address != null)
            {
                await _addressrepository.DeleteAsync(id);
            }
        }

    }
}
