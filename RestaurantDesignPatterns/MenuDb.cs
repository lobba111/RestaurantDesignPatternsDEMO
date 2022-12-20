using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public static class MenuDb
    {
        public static List<MenuItem> GetMenu()
        {
            return new List<MenuItem>
            {
                new MenuItem("Lasagne",50),
                new MenuItem("Bolognese",70),
                new MenuItem("Cheseburger",40)
            };
        }
    }
}
