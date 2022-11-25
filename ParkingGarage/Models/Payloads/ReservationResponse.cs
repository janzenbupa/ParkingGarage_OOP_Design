using System;
using ParkingGarage.Models;

namespace ParkingGarage.Models.Payloads
{
    public class ReservationResponse
    {
        public long ReservationId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
        public string ResponseCode { get; set; }
    }
}