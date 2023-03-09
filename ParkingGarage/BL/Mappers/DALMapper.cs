using ParkingGarage.Models.Enums;

namespace ParkingGarage.BL.Mappers
{
    public static class DALMapper
    {
        public static DAL.Models.Reservation BuildReservationRequest(Models.Payloads.ReservationRequest request, long carId)
        {
            DAL.Models.Reservation r = new DAL.Models.Reservation
            {
                ReservationId = request.ReservationId,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(request.Length),
                CarId = carId,
                SpaceId = request.ParkingSpace.SpaceId
            };

            return r;
        }



        public static DAL.Models.Car BuildCar(Models.Car car)
        {
            return new DAL.Models.Car
            {
                Color = car.Color.ToString(),
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                Brand = car.Brand,
                CarTypeId = (int)car.CarType
            };
        }

        public static DAL.Models.ParkingSpace BuildParkingSpace(Models.ParkingSpace parkingSpace)
        {
            return new DAL.Models.ParkingSpace
            {
                SpaceId = parkingSpace.SpaceId,
                IsOpen = parkingSpace.IsOpen,
                CarType = (int)parkingSpace.CarType
            };
        }

        public static Models.ParkingSpace BuildParkingSpace(DAL.Models.ParkingSpace parkingSpace)
        {
            return new Models.ParkingSpace
            {
                SpaceId = parkingSpace.SpaceId,
                IsOpen = parkingSpace.IsOpen,
                CarType = (CarTypeEnum)parkingSpace.CarType
            };
        }
    }
}
