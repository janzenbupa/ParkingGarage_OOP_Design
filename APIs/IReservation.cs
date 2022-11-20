using System;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.APIs
{
    public interface IReversation
    {
        //This is an HTTP POST method
        ReservationResponse Post(ReservationRequest request);
    }
}