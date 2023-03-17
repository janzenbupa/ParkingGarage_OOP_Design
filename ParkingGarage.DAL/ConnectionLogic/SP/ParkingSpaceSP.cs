using Microsoft.Extensions.Configuration;
using ParkingGarage.DAL.ConnectionLogic.SP.Interfaces;
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
    public class ParkingSpaceSP : IParkingSpaceSP
    {

        //This class probably needs to be rebuilt to not call a database object that returns an entire row. 

        private readonly string _connectionString;

        public ParkingSpaceSP(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(ServiceSettings.DatabaseName);
        }

        public async Task<G> GetOrSave<T, G>(T obj)
        {
            ParkingSpace ans = new ParkingSpace();

            var parkingSpace = obj as ParkingSpace;

            SqlDataReader reader = null;

            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCom = new SqlCommand("exec dbo.GetParkingSpace @spaceId, @isOpen, @carType", sqlCon))
                {
                    sqlCom.Parameters.Add(new SqlParameter("@spaceId", parkingSpace.SpaceId));
                    sqlCom.Parameters.Add(new SqlParameter("@isOpen", parkingSpace.IsOpen));
                    sqlCom.Parameters.Add(new SqlParameter("@carType", parkingSpace.CarType));

                    sqlCon.Open();

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

            return (G)Convert.ChangeType(ans, typeof(G));
        }
    }
}
