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
        public async Task<ReservationResponse> Post(ReservationRequest request)
        {
            var response = await _parkingGarage.ProcessRequest(request);

            return response;
        }
    }
}
