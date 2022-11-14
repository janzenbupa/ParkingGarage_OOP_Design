using System;



namespace ParkingGarage.Models
{
    public class PaymentInformation
    {
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public string CardholderName { get; set; }
    }
}