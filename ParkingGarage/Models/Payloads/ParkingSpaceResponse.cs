using System;
using System.Collections.Generic;
using ParkingGarage.Models;

namespace ParkingGarage.Models.Payloads
{
    public class ParkingSpaceResponse
    {
        public List<ParkingSpace> ParkingSpaces { get; set; }
    }
}