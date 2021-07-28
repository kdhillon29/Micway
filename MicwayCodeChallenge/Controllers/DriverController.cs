using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicwayCodeChallenge.Entities;
using MicwayCodeChallenge.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicwayCodeChallenge.Controllers
{
    [ApiController]
    [Route("api/Driver")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger, IDriverRepository driverRepository)
        {
            _logger = logger;
            _driverRepository = driverRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Driver>> GetDriverListAsync()
        {
             var driverList  = await _driverRepository.GetDriverListAsync();
            return driverList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriverAsync(Guid id)
        {
            var driver =  await _driverRepository.GetDriverByIdAsync(id);
            if (driver is null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpPost]
        public async Task<ActionResult> AddDriverAsync(Driver newDriver)
        {
            try
            {
                await _driverRepository.AddDriverAsync(newDriver);
                return Ok(newDriver);
              
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddDriverAsync Exception {ex.Message}");
                return StatusCode(500, new { Error = $"InternalServer Error {newDriver} not saved " });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDriverAsync(Guid id, Driver updateDriver)
        {
            try
            {
                await  _driverRepository.UpdateDriverAsync(updateDriver);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateDriverAsync Exception {ex.Message}");
                return StatusCode(500, new { Error = $"InternalServer Error! driver not updated " });
            }

            

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriverAsync(Guid id)
        {
            try
            {
                await _driverRepository.DeleteDriverAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteDriverAsync Exception {ex.Message}");
                return StatusCode(500, new { Error = $"InternalServer Error driver with {id} not deleted " });
            }
        }

    }
}