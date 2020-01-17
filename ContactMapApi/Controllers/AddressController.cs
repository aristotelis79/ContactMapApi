using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddressViewModel model, CancellationToken token = default)
        {
        }


    }
}
