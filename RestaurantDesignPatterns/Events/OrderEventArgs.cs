using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.Events
{
    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }    
    }
}
