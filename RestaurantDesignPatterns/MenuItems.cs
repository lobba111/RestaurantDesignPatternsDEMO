using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
   public class MenuItem
    {
        private string _dishname;
        private float _price;
        public string Dishname => _dishname;
        public float Price => _price;
        public MenuItem(string dishname, float price)
        {
            _dishname = dishname;
            _price = price;
        }
    }
    
}
