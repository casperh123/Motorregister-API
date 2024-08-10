using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MotorRegister.Core.Api;

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
            VehicleDTO vehicle = await _vehicleRepository.GetVehicleByLicensePlate(licensePlate);
            if (vehicle == null)
            {
                return NotFound(new { Message = $"Vehicle with license plate {licensePlate} not found." });
            }
            return Ok(vehicle);
        }
        
        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetVehicles([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            long totalRecords = await _vehicleRepository.GetVehicleCountAsync();
            List<VehicleDTO> vehicles = await _vehicleRepository.GetVehicles(pageSize, pageNumber);
            
            PaginatedResponse<VehicleDTO> paginatedResponse = new PaginatedResponse<VehicleDTO>(vehicles, totalRecords, pageNumber, pageSize);

            return Ok(paginatedResponse);
        }

    }
}