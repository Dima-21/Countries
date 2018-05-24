using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WinForms2
{
    [Serializable]
    class Countries
    {
        public string Country { get; set; }
        public List<string> Cities { get; set; }
        public Countries(string country)
        {
            Cities = new List<string>();
            Country = country;
        }
        public void Add(string city)
        {
            Cities.Add(city);
        }

        public void Delete(string city)
        {
            Cities.Remove(city);
        }

        public void Rename(string oldCity, string newCity)
        {
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i] == oldCity)
                    Cities[i] = newCity;
            }
            
        }



    }
}
