using Microsoft.Extensions.Configuration;
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
    public class CarSP : IStoredProcedure
    {
        private readonly string _connectionString;

        public CarSP(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(ServiceSettings.DatabaseName) ?? String.Empty;
        }

        public async Task<long> Save<T>(T obj)
        {
            var car = obj as Car;

            long ans = -1;

            SqlDataReader reader = null;

            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCom = 
                    new SqlCommand("exec dbo.SaveCar @carId, @color, @brand, @carTypeId, @year, @licensePlate", sqlCon))
                {

                    sqlCom.Parameters.Add(new SqlParameter("@carId", car.CarId));
                    sqlCom.Parameters.Add(new SqlParameter("@color", car.Color));
                    sqlCom.Parameters.Add(new SqlParameter("@brand", car.Brand));
                    sqlCom.Parameters.Add(new SqlParameter("@carTypeId", car.CarTypeId));
                    sqlCom.Parameters.Add(new SqlParameter("@year", car.Year));
                    sqlCom.Parameters.Add(new SqlParameter("@licensePlate", car.LicensePlate));

                    sqlCon.Open();

                    await sqlCom.ExecuteNonQueryAsync();

                    reader = sqlCom.ExecuteReader();
                }

                while (reader != null && reader.Read())
                {
                    ans = Convert.ToInt64(reader["CarId"]);
                }

            }

            return ans;
        }
    }
}
