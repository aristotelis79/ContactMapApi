using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;
using ContactMapApi.Repository;

namespace ContactMapApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public async Task<Address> InsertAsync(Address address, bool saveChanges = true, CancellationToken token = default)
        {
            return (await _addressRepository.InsertAsync(address, saveChanges, token)
                       .ConfigureAwait(false)) > 0
                ? address
                : null;
        }

        public async Task<IList<Address>> InsertAsync(IList<Address> addresses, bool saveChanges = true, CancellationToken token = default)
        {
            return (await _addressRepository.InsertAsync(addresses, saveChanges, token)
                       .ConfigureAwait(false)) > 0
                ? addresses
                : null;
        }

        public async Task<bool> DeleteAsync(Address address, bool saveChanges = true, CancellationToken token = default)
        {
            return await _addressRepository.DeleteAsync(address, saveChanges, token)
                       .ConfigureAwait(false) > 0;
        }


        public async Task<bool> DeleteAsync(IList<Address> addresses, bool saveChanges = true, CancellationToken token = default)
        {
            return await _addressRepository.DeleteAsync(addresses, saveChanges, token)
                       .ConfigureAwait(false) > 0;
        }
    }
}