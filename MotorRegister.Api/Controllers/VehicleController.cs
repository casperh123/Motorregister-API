using Microsoft.AspNetCore.Mvc;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using System.Threading.Tasks;

namespace MotorRegister.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(ILogger<VehicleController> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }
        
        [HttpGet("GetVehicleFromLicensePlate/{licensePlate}")]
        public async Task<IActionResult> GetVehicleFromLicensePlateAsync(string licensePlate)
        {
            var vehicle = await _vehicleRepository.GetVehicleByLicensePlate(licensePlate);
            if (vehicle == null)
            {
                return NotFound(new { Message = $"Vehicle with license plate {licensePlate} not found." });
            }
            return Ok(vehicle);
        }
    }
}