using ParkingGarage.BL.Mappers;
using ParkingGarage.BL.SharedLogic;
using ParkingGarage.DAL.ConnectionLogic.cs.SP;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.BL
{
    public class ReservationLogic : IParkingGarage<ReservationResponse, ReservationRequest>
    {
        private readonly IShare _sharedLogic;

        public ReservationLogic(IShare sharedLogic)
        {
            _sharedLogic = sharedLogic;
        }





        public async Task<ReservationResponse> ProcessRequest(ReservationRequest request)
        {
            //call database and perform logic to process a request.
            var car = await _sharedLogic.GetOrSaveCar(request.Car);

            var parkingSpaceDAL = await _sharedLogic.GetAvailableSpace(request.ParkingSpace);

            if (parkingSpaceDAL == null || parkingSpaceDAL.IsOpen == false)
            {
                throw new Exception("There are no available parking spaces for this car type");
            }

            var reservation = DALMapper.BuildReservationRequest(request, car);

            var reservationId = await ReservationSP.SaveReservation(reservation);

            var parkingSpace = DALMapper.BuildParkingSpace(parkingSpaceDAL);

            return new ReservationResponse { ReservationId = reservationId, ParkingSpace = parkingSpace };
        }
    }
}
