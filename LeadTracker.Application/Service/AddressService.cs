using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            var address = await _addressrepository.GetByIdAsync(id);

            var addressDTO = _mappingProfile.Map<AddressDTO>(address);
            return addressDTO;
        }


        public async Task<IEnumerable<AddressDTO>> GetAllAddressAsync()
        {
            var addresses = await _addressrepository.GetAllAsync();

            var addressDTOs = _mappingProfile.Map<List<AddressDTO>>(addresses);

            return addressDTOs.ToList();
        }

        public async Task UpdateAddressAsync(int id, AddressDTO address)
        {
            var existingAddress = await _addressrepository.GetByIdAsync(id);


            _mappingProfile.Map(address, existingAddress);


            await _addressrepository.UpdateAsync(existingAddress);


            //var adr = _mappingProfile.Map<Address>(address);
            //await _addressrepository.UpdateAsync(adr);

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
