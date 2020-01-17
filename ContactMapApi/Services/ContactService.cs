using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;
using ContactMapApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactMapApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IAddressService _addressService;

        public ContactService(IRepository<Contact> contactRepository, IAddressService addressService)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
        }


        public async Task<List<Contact>> GetAll(CancellationToken token = default)
        {
            return await _contactRepository.Table
                .Include(x => x.Addresses)
                .ToListAsync(token).ConfigureAwait(false);
        }

        public async Task<Contact> InsertAsync(Contact contact, bool saveChanges = true, CancellationToken token = default)
        {
            var contactInsert = _contactRepository.InsertAsync(contact, saveChanges, token);

            var addressInsert = _addressService.InsertAsync(contact.Addresses.ToList(), saveChanges, token);

            await Task.WhenAll(contactInsert, addressInsert).ConfigureAwait(false);

            return await _contactRepository.SaveChangesAsync(token).ConfigureAwait(false) > 0 ? contact : null;
        }

        public async Task<bool> DeleteAsync(Contact contact, bool saveChanges = true, CancellationToken token = default)
        {
            return await _contactRepository.DeleteAsync(contact, saveChanges, token)
                                            .ConfigureAwait(false) > 0;
        }
    }
}