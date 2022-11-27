using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.BL;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {
        private readonly IParkingGarage<ParkingSpaceResponse> _parkingGarage;

        public ParkingSpaceController(IParkingGarage<ParkingSpaceResponse> parkingGarage)
        {
            _parkingGarage = parkingGarage;
        }


        [HttpGet]
        public ParkingSpaceResponse Get()
        {
            //perform db logic to return a list of parking spaces
            var response = _parkingGarage.ProcessRequest();

            return response;
        }
    }
}
