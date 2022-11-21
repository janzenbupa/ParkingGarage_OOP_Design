using System;
using System.Collections.Generic;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.APIs
{
    public interface IParkingSpace
    {
        //GET request method
        ParkingSpaceResponse Get();
    }
}