using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public class OrderCountBuilder<T>: OrderInfoBuilder<OrderCountBuilder<T>> where T: OrderCountBuilder<T>
    {
        public T SetCount(int count)
        {
            order.Count = count;
            return (T)this;
        }
    }
}
