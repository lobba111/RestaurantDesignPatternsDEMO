using RestaurantDesignPatterns.FluentBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class UI
    {
        public void PrintUI()
        {
            Console.WriteLine("Enter restaurant? y/n");
            string answer = Console.ReadLine();
            while (answer[0] == 'y')
            {
                Console.WriteLine("This is our menu");
                var menu = MenuDb.GetMenu();
                int i = 1;
                foreach (var item in menu)
                {
                    Console.WriteLine($"{item.Dishname} ORDER NUMBER {i}");
                    i++;
                }
                Console.WriteLine("Select food");
                var select = Console.ReadLine();
                GenerateNowOrder(select);
                Console.WriteLine("Do you want to order more? y/n");
                answer = Console.ReadLine();
            }
        }

        private void GenerateNowOrder(string? select)
        {
            var menu = MenuDb.GetMenu();
            int value = Convert.ToInt32(select);
            value = value - 1;
            Order order = new Order();
            var orderBUilder =  OrderBuilderDirector
                .NewOrder
                .SetOrderStatus(OrderStatus.Waiting)
                .SetDishName(menu.ElementAt(value))
                .SetCount(1)
                .Build();
            order.MenuItem = menu.ElementAt(value);
            order.Count = 1;
            order.Status = OrderStatus.Waiting;
            OrderQue.Instance.AddOrder(orderBUilder);
        }
    }
}
