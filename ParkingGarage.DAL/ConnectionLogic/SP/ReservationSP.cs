using Microsoft.Extensions.Configuration;
using ParkingGarage.DAL.ConnectionLogic.SP;
using ParkingGarage.DAL.ConnectionLogic.SP.Interfaces;
using ParkingGarage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.ConnectionLogic.cs.SP
{
    public class ReservationSP : IReservationSP
    {
        private readonly string _connectionString;

        public ReservationSP(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(ServiceSettings.DatabaseName);
        }

        public async Task<G> GetOrSave<T, G>(T obj)
        {
            long ans = -1;
            var reservation = obj as Reservation;

            SqlDataReader reader = null;

            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCom = 
                    new SqlCommand("exec dbo.SaveReservation @rId, @startTime, @endTime, @carId, @spaceId", sqlCon))
                {
                    sqlCom.Parameters.Add(new SqlParameter("@rId", reservation.ReservationId));
                    sqlCom.Parameters.Add(new SqlParameter("@startTime", reservation.StartTime));
                    sqlCom.Parameters.Add(new SqlParameter("@endTime", reservation.EndTime));
                    sqlCom.Parameters.Add(new SqlParameter("@spaceId", reservation.SpaceId));
                    sqlCom.Parameters.Add(new SqlParameter("@carId", reservation.CarId));

                    sqlCon.Open();

                    await sqlCom.ExecuteNonQueryAsync();

                    reader = sqlCom.ExecuteReader();
                }

                while (reader != null && reader.Read())
                {
                    ans = Convert.ToInt64(reader["Reservation"]);
                }
                
            }

            return (G)Convert.ChangeType(ans, typeof(G));
        }
    }
}
