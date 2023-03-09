using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.BL;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IParkingGarage<PaymentResponse, PaymentRequest> _parkingGarage;

        public PaymentController(IParkingGarage<PaymentResponse, PaymentRequest> parkingGarage)
        {
            _parkingGarage = parkingGarage;
        }



        [HttpPost]
        public async Task<PaymentResponse> Post(PaymentRequest request)
        {
            //This could be it's own service that accepts and processes payments.
            var response = await _parkingGarage.ProcessRequest(request);
            return response;
        }
    }
}
