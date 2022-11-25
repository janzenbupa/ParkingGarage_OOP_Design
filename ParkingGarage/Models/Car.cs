using ParkingGarage.Models.Enums;
using System;

namespace ParkingGarage.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Year { get; set; }
        public ColorEnum Color { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string LicensePlate { get; set; }
    }
}