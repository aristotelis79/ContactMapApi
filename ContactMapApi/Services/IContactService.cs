using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.App_Data.Entities;

namespace ContactMapApi.Services
{
    public interface IContactService
    {
        Task<Contact> GetById(Guid id, CancellationToken token = default);
        Task<List<Contact>> GetAll(CancellationToken token = default);
        Task<Contact> InsertAsync(Contact contact, CancellationToken token = default);
        Task<bool> DeleteAsync(Contact contact, CancellationToken token = default);
    }
}