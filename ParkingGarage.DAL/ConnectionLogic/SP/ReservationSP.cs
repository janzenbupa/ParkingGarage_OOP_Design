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
    public static class ReservationSP
    {
        private static readonly string _connectionString;

        static ReservationSP()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[ServiceSettings.DatabaseName].ConnectionString;
        }

        public static async Task<long> SaveReservation(Reservation reservation)
        {
            long ans = -1;

            SqlDataReader reader = null;

            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCom = new SqlCommand("exec dbo.SaveReservation", sqlCon))
                {
                    sqlCom.Parameters.AddWithValue("@rId", reservation.ReservationId);
                    sqlCom.Parameters.AddWithValue("@startTime", reservation.StartTime);
                    sqlCom.Parameters.AddWithValue("@endTime", reservation.EndTime);
                    sqlCom.Parameters.AddWithValue("@spaceId", reservation.SpaceId);
                    sqlCom.Parameters.AddWithValue("@carId", reservation.CarId);

                    await sqlCom.ExecuteNonQueryAsync();

                    reader = sqlCom.ExecuteReader();
                }

                while (reader != null && reader.Read())
                {
                    ans = Convert.ToInt64(reader["@Reservation"]);
                }
                
            }

            return ans;
        }
    }
}
