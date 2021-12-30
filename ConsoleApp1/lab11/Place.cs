using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Place
    {
        public string Store { get; set; }
        public string City { get; set; }
        public Place(string store, string city)
        {
            Store = store;
            City = city;
        }
    }
}
