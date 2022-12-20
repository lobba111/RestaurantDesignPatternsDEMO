using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class Waiter
    {
        public WorkStatus WorkStatus { get; set; } = WorkStatus.Idle;
        public List<Order> Order { get; set; } = new List<Order>();
        protected Thread _thread;
        public void GetOrder(Order order) { Order.Add(order); }
        public void DeliverOrder() { }
    }
}
