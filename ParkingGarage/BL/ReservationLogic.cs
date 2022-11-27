using ParkingGarage.Models.Payloads;

namespace ParkingGarage.BL
{
    public class ReservationLogic : IParkingGarage<ReservationResponse, ReservationRequest>
    {
        public ReservationResponse ProcessRequest(ReservationRequest request)
        {
            //call database and perform logic to process a request.
            return new ReservationResponse();
        }
    }
}
