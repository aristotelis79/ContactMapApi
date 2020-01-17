using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;

namespace ContactMapApi.Services
{
    public interface IAddressService
    {
        Task<Address> InsertAsync(Address address, bool saveChanges = true, CancellationToken token = default);
        Task<IList<Address>> InsertAsync(IList<Address> addresses, bool saveChanges = true, CancellationToken token = default);
        Task<bool> DeleteAsync(Address address, bool saveChanges = true, CancellationToken token = default);
        Task<bool> DeleteAsync(IList<Address> addresses, bool saveChanges = true, CancellationToken token = default);
    }
}