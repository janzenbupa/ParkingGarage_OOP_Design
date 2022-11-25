using System;
using ParkingGarage.Models;



namespace ParkingGarage.Models.Payloads
{
    public class ReservationRequest
    {
        public long ReservationId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
        public Car Car { get; set; }
    }
}