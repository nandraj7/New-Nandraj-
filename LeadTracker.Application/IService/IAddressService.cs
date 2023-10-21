using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IAddressService
    {
        Task CreateAddress(AddressDTO address);

        Task<AddressDTO> GetAddressByIdAsync(int id);

        Task<IEnumerable<AddressDTO>> GetAllAddressAsync();

        Task UpdateAddressAsync(int id, AddressDTO address);

        Task DeleteAddressAsync(int id);
    }
}
