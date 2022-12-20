using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class Menu
    {
        private List<MenuItem> _menu;
        public List<MenuItem> MenuItems => _menu;
        public Menu()
        {
            _menu = MenuDb.GetMenu();           
        }
       
    }
}
