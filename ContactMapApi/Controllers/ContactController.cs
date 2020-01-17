using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Models;
using ContactMapApi.Models.Mapper;
using ContactMapApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactMapApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok((await _contactService.GetAll(token).ConfigureAwait(false)).ToViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactViewModel model, CancellationToken token = default)
        {
            try
            {
                 await _contactService.InsertAsync(model.ToEntity(), token).ConfigureAwait(false);
                
                return Ok(model);
            }
        
            catch (Exception e)
            {
                _logger.LogError("Can't create contact", e);
                return new ContentResult
                {
                    Content = "Can't create contact",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token = default)
        {
            try
            {
                var entity = await _contactService.GetById(id,token)
                    .ConfigureAwait(false);

                if(entity == null) return new ContentResult
                {
                    Content = "Didn't find it",
                    StatusCode = StatusCodes.Status404NotFound
                };

                await _contactService.DeleteAsync(entity, token)
                    .ConfigureAwait(false);

                return new ContentResult
                {
                    Content = $"Deleted contact with id:${id}",
                    StatusCode = StatusCodes.Status205ResetContent
                };
            }
            catch(Exception e)
            {
                _logger.LogError("Can't delete contact", e);
                return new ContentResult
                {
                    Content = "Can't delete contact",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
