using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {
        [HttpGet]
        public ParkingSpaceResponse Get()
        {
            //perform db logic to return a list of parking spaces
            return new ParkingSpaceResponse();
        }
    }
}
