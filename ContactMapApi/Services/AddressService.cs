using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.App_Data.Entities;
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

        public async Task<Address> InsertAsync(Address address, CancellationToken token = default, bool saveChanges = true)
        {
            return (await _addressRepository.InsertAsync(address,token,saveChanges)
                       .ConfigureAwait(false)) > 0
                ? address
                : null;
        }

        public async Task<IList<Address>> InsertAsync(IList<Address> addresses, CancellationToken token = default, bool saveChanges = true)
        {
            return (await _addressRepository.InsertAsync(addresses, token, saveChanges)
                       .ConfigureAwait(false)) > 0
                ? addresses
                : null;
        }

        public async Task<bool> DeleteAsync(Address address, CancellationToken token = default)
        {
            return await _addressRepository.DeleteAsync(address, token)
                       .ConfigureAwait(false) > 0;
        }


        public async Task<bool> DeleteAsync(IList<Address> addresses, CancellationToken token = default)
        {
            return await _addressRepository.DeleteAsync(addresses, token)
                       .ConfigureAwait(false) > 0;
        }
    }
}