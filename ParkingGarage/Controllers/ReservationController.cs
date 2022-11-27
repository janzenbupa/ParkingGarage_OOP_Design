using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.BL;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IParkingGarage<ReservationResponse, ReservationRequest> _parkingGarage;

        public ReservationController(IParkingGarage<ReservationResponse, ReservationRequest> parkingGarage)
        {
            _parkingGarage = parkingGarage;
        }


        [HttpPost]
        public ReservationResponse Post(ReservationRequest request)
        {
            var response = _parkingGarage.ProcessRequest(request);

            return response;
        }
    }
}
