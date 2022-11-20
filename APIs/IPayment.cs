using System;
using ParkingGarage.Models.Payloads;

namespace ParkingGarage.APIs
{
    public interface IPayment
    {
        public PaymentResponse Post(PaymentRequest request);
    }
}