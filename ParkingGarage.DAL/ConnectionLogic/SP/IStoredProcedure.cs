using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.ConnectionLogic.SP
{
    public interface IStoredProcedure
    {
        Task<G> GetOrSave<T, G>(T obj);
    }
}
