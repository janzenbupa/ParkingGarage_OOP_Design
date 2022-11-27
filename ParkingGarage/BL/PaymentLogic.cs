using ParkingGarage.Models.Payloads;

namespace ParkingGarage.BL
{
    public class PaymentLogic : IParkingGarage<PaymentResponse, PaymentRequest>
    {
        public PaymentResponse ProcessRequest(PaymentRequest request)
        {
            //Perform logic to process the payment
            return new PaymentResponse();
        }
    }
}
