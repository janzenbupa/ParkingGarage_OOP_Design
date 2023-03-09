using ParkingGarage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.DAL.ConnectionLogic.SP
{
    public static class ParkingSpaceSP
    {
        private static readonly string _connectionString;

        static ParkingSpaceSP()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[ServiceSettings.DatabaseName].ConnectionString;
        }

        public static async Task<DAL.Models.ParkingSpace> SaveOrGetParkingSpace(ParkingSpace parkingSpace)
        {
            ParkingSpace ans = new ParkingSpace();

            SqlDataReader reader = null;

            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCom = new SqlCommand("exec dbo.GetParkingSpace", sqlCon))
                {
                    sqlCom.Parameters.AddWithValue("@spaceId", parkingSpace.SpaceId);
                    sqlCom.Parameters.AddWithValue("@isOpen", parkingSpace.IsOpen);
                    sqlCom.Parameters.AddWithValue("@carType", parkingSpace.CarType);

                    await sqlCom.ExecuteNonQueryAsync();

                    reader = sqlCom.ExecuteReader();
                }

                while (reader != null && reader.Read())
                {
                    ans.SpaceId = Convert.ToInt64(reader["SpaceId"]);
                    ans.IsOpen = Convert.ToBoolean(reader["IsOpen"]);
                    ans.CarType = Convert.ToInt32(reader["CarType"]);
                }

            }

            return ans;
        }
    }
}
