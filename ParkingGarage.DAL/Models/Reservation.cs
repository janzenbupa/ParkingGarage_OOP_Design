using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.Models
{
    public class Reservation
    {
        public long ReservationId { get; set; }
        public long SpaceId { get; set; }
        public long CarId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
