using ParkingGarage.Models;

namespace ParkingGarage.BL.SharedLogic
{
    public interface IShare
    {
        /// <summary>
        /// This will determine if the space is available and return either the requested space or an available space. 
        /// </summary>
        /// <param name="spaceId"></param>
        /// <returns></returns>
        public Task<DAL.Models.ParkingSpace> GetAvailableSpace(long spaceId, int carType);

        public Task<DAL.Models.ParkingSpace> GetAvailableSpace(Models.ParkingSpace parkingSpace);

        /// <summary>
        /// This will return the car object ID from the database, or save the car into the database and return the ID. 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Task<long> GetOrSaveCar(Car car);
    }
}
