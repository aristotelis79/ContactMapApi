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
        private readonly IRepository<Contact> _contactRepository;

        public AddressService(IRepository<Address> addressRepository, IRepository<Contact> contactRepository)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<Address> InsertAsync(Address address, CancellationToken token = default, bool saveChanges = true)
        {
            var contact = await _contactRepository.GetByIdAsync(address.ContactId, token).ConfigureAwait(false);
            
            if (contact == null) return null;

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