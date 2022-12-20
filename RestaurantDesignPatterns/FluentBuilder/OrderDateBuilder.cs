using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public class OrderDateBuilder<T>: OrderStatusBuilder<OrderDateBuilder<T>> where T : OrderDateBuilder<T>
    {
        public T SetDate()
        {
            order.DateOrderd = DateTime.Now;
            return (T)this;
        }
    }
}
