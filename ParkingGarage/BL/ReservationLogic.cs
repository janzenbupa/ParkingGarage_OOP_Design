using ParkingGarage.BL.Mappers;
using ParkingGarage.DAL.ConnectionLogic.cs.SP;
using ParkingGarage.DAL.ConnectionLogic.SP;
using ParkingGarage.DAL.ConnectionLogic.SP.Interfaces;
using ParkingGarage.Models;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.BL
{
    public class ReservationLogic : IParkingGarage<ReservationResponse, ReservationRequest>
    {
        private readonly IDictionary<string, IStoredProcedure> _storedProcedures;
        public ReservationLogic(IDictionary<string, IStoredProcedure> storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }





        public async Task<ReservationResponse> ProcessRequest(ReservationRequest request)
        {
            //call database and perform logic to process a request.
            var car = DALMapper.BuildCar(request.Car);
            var carId = await ((ICarSP)_storedProcedures["CarSP"]).GetOrSave<DAL.Models.Car, long>(car);

            var parkingSpaceDAL = await ((IParkingSpaceSP)_storedProcedures["ParkingSpaceSP"])
                .GetOrSave<DAL.Models.ParkingSpace, DAL.Models.ParkingSpace>(DALMapper.BuildParkingSpace(request.ParkingSpace));

            if (parkingSpaceDAL == null || parkingSpaceDAL.IsOpen == false)
            {
                throw new Exception("There are no available parking spaces for this car type");
            }

            var reservation = DALMapper.BuildReservationRequest(request, carId, parkingSpaceDAL.SpaceId);

            var reservationId = await ((IReservationSP)_storedProcedures["ReservationSP"])
                .GetOrSave<DAL.Models.Reservation, long>(reservation);

            var parkingSpace = DALMapper.BuildParkingSpace(parkingSpaceDAL);

            return new ReservationResponse { ReservationId = reservationId, ParkingSpace = parkingSpace };
        }
    }
}
