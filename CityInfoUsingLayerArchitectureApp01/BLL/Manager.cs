using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityInfoUsingLayerArchitectureApp01.DAL;

namespace CityInfoUsingLayerArchitectureApp01.BLL
{
    class Manager
    {
        GateWay gateway = new GateWay();

        public string Save(City aCity)
        {
            if (gateway.IsCityNameExist(aCity.CityName))
            {
                return "City name Already exist";
            }
            if (aCity.CityName.Length > 3)
            {
                if (gateway.Save(aCity) > 0)
                {
                    return "Insertion Successful";
                 
                }
                else
                {
                    return "Insertion Faild!";
                }
            }
            else
            {
                return "City name is less than 4 character.";
            }
        }

        public List<City> ShowAllCities()
        {
            return gateway.ShowAllCityInformation();
        }
    }
}
