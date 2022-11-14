using System;

namespace ParkingGarage.Models.Payloads
{
    public class PaymentResponse
    {
        public long Id { get; set; }//Payment Request identifier.
        public string ResponseCode { get; set; }
    }
}