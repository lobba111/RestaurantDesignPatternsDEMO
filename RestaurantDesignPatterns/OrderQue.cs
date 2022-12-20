using RestaurantDesignPatterns.Events;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class OrderQue
    {
        public event EventHandler<OrderEventArgs> OrderAdded;
        private Queue<Order> _orders;
        public Queue<Order> Orders => _orders;
        public OrderQue()
        {
            _orders = new Queue<Order>();
        }

        public void AddOrder(Order order) 
        {
            Orders.Enqueue(order);
            OnOrderAdded(order);
        }
        protected virtual void OnOrderAdded(Order order)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs { Order = order });
        }
        public void RemoveOrder() 
        {
           Ticket.TicketOrders.Add(Orders.Dequeue()); 
        }
        public static OrderQue Instance { get; } = new OrderQue();
    }
}
