using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.Models
{
    public class ParkingSpace
    {
        public long SpaceId { get; set; }
        public bool IsOpen { get; set; }
        public int CarType { get; set; }
    }
}
