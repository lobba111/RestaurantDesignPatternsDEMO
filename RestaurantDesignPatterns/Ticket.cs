using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public static class Ticket
    {
        public static string TicketName { get; set; } = DateTime.Now.ToString();
        public static List<Order> TicketOrders { get; set; } = new List<Order>();
        private static int AmountOfDishSold { get; set; } = 0;
        private static int Ernings { get; set; } = 0;    
        public static void PrintSales()
        {
            foreach (var item in TicketOrders)
            {
                AmountOfDishSold += item.Count;
                Ernings += (int)item.MenuItem.Price * item.Count;
            }
            Console.WriteLine($"Total dishes sold = {AmountOfDishSold}, Revenue Generated = {Ernings}, At {TicketName}");
        }
    }
}
