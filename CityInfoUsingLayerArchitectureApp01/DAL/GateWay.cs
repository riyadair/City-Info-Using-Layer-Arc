using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CityInfoUsingLayerArchitectureApp01.BLL;
using CityInfoUsingLayerArchitectureApp01.UI;

namespace CityInfoUsingLayerArchitectureApp01.DAL
{
    class GateWay
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CityInfoConString"].ConnectionString;
        //Manager manager = new Manager();
        public int Save(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO tbl_City VALUES('"+aCity.CityName+"','"+aCity.About+"','"+aCity.Country+"')";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsCityNameExist(string cityName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM tbl_city WHERE city_name ='" + cityName + "'";

            SqlCommand command = new SqlCommand(query, connection);
            bool isCityNameExist = false;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isCityNameExist = true;
                break;
            }
            reader.Close();
            connection.Close();

            return isCityNameExist;
        }

        public List<City> ShowAllCityInformation()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_city";
            SqlCommand command = new SqlCommand(query,connection);
            List<City> cityList = new List<City>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                City aCity = new City();
                aCity.CityName = reader["city_name"].ToString();
                aCity.About = reader["about"].ToString();
                aCity.Country = reader["country"].ToString();

                cityList.Add(aCity);
            }
            reader.Close();
            connection.Close();

            return cityList;
        }
        
    }
}
