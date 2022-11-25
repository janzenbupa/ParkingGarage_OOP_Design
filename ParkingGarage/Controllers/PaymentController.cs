using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public PaymentResponse Post(PaymentRequest request)
        {
            //This could be it's own service that accepts and processes payments.
            return new PaymentResponse();
        }
    }
}
