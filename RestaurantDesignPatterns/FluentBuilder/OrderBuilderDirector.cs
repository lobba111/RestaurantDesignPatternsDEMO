using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.FluentBuilder
{
    public class OrderBuilderDirector : OrderDateBuilder<OrderBuilderDirector>
    {
        public static OrderBuilderDirector NewOrder => new OrderBuilderDirector();
    }
}
