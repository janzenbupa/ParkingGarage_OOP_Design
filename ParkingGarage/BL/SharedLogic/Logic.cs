using ParkingGarage.BL.Mappers;
using ParkingGarage.DAL.ConnectionLogic.SP;
using ParkingGarage.Models;
using ParkingGarage.Models.Enums;

namespace ParkingGarage.BL.SharedLogic
{
    internal class Logic : IShare
    {
        private readonly IStoredProcedure _storedProcedure;
        public Logic(IStoredProcedure storedProcedure)
        {
            _storedProcedure = storedProcedure;
        }
        public async Task<DAL.Models.ParkingSpace> GetAvailableSpace(long spaceId, int carType)
        {
            //I will implement. Need to call the database and retrieve a valid space.
            //Requires DAL updates and this simple implementation. 
            return await GetAvailableSpace(new ParkingSpace { SpaceId = spaceId, CarType = (CarTypeEnum)carType });
        }


        public async Task<DAL.Models.ParkingSpace> GetAvailableSpace(ParkingSpace parkingSpace)
        {
            var space = DALMapper.BuildParkingSpace(parkingSpace);

            return await ParkingSpaceSP.SaveOrGetParkingSpace(space);

        }



        public async Task<long> GetOrSaveCar(Car car)
        {
            var c = DALMapper.BuildCar(car);
            long carId = await _storedProcedure.Save(c);

            return carId;
        }
    }
}
