using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;

namespace ContactMapApi.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll(CancellationToken token = default);
        Task<Contact> InsertAsync(Contact contact, bool saveChanges = true, CancellationToken token = default);
        Task<bool> DeleteAsync(Contact contact, bool saveChanges = true, CancellationToken token = default);
    }
}