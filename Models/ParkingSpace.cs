using System;
using Enums;



namespace ParkingGarage.Models
{
    public class ParkingSpace
    {
        public long SpaceId { get; set; }
        public bool IsOpen { get; set; }
        public CarTypeEnum CarType { get; set; }
    }   
}