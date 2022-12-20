using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public abstract class OrderBuilder
    {
        protected Order order;
        public OrderBuilder()
        {
            order = new Order();    
        }
        public Order Build() => order;
    }
}
