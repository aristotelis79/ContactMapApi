﻿using System;
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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(ILogger<AddressController> logger, IAddressService addressService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddressViewModel model, CancellationToken token = default)
        {
            try
            {
                await _addressService.InsertAsync(model.ToEntity(), token);

                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError("Can't create address", e);
                return new ContentResult
                {
                    Content = "Can't create address",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}