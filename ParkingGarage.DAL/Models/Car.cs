using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.Models
{
    public class Car
    {
        public long CarId { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public int CarTypeId { get; set; }
        public string LicensePlate { get; set; }
    }
}
