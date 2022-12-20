using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public class OrderInfoBuilder<T>: OrderBuilder where T : OrderInfoBuilder<T>
    {
        public T SetDishName(MenuItem menuItem)
        {
            order.MenuItem = menuItem;
            return (T)this;
        }
    }
}
