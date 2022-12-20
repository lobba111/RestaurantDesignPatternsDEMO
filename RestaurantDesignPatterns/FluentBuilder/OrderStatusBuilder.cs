using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public class OrderStatusBuilder<T>: OrderCountBuilder<OrderStatusBuilder<T>> where T : OrderStatusBuilder<T>
    {
        public T SetOrderStatus(OrderStatus orderStatus)
        {
            order.Status = orderStatus;
            return (T)this;
        }
    }
}
