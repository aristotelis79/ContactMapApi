using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.App_Data.Entities;

namespace ContactMapApi.Services
{
    public interface IAddressService
    {
        Task<Address> InsertAsync(Address address, CancellationToken token = default, bool saveChanges = true );
        Task<IList<Address>> InsertAsync(IList<Address> addresses, CancellationToken token = default, bool saveChanges = true );
        Task<bool> DeleteAsync(Address address, CancellationToken token = default);
        Task<bool> DeleteAsync(IList<Address> addresses, CancellationToken token = default);
    }
}