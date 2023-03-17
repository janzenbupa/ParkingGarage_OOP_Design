using ParkingGarage.Models;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.BL
{
    public class ParkingSpaceLogic : IParkingGarage<ParkingSpaceResponse>, IParkingGarage<bool, ParkingSpace>
    {
        public ParkingSpaceResponse ProcessRequest()
        {
            //Call database to retrieve parking spaces
            return new ParkingSpaceResponse { ParkingSpaces = new List<ParkingSpace>() };
        }

        public async Task<bool> ProcessRequest(ParkingSpace request)
        {
            //Call database, ensure parking space is currently free, set parking space to in-use (unavailable)
            

            return true;//return true if reserving space succeeded
        }

    }
}
