using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class Order
    {
       public MenuItem MenuItem { get; set; }
       public int Count { get; set; }
       public OrderStatus Status  = OrderStatus.Waiting;
       public DateTime DateOrderd { get; set; } = DateTime.Now;
    }
}
