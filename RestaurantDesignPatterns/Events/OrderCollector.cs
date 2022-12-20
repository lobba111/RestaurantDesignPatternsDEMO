using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.Events
{
    public class OrderCollector
    {
        public event EventHandler<OrderEventArgs> OrderWorkPrepared;
        public void GetWork()
        {
            //utför jobb där jag tittar om något har lagts till i kön detta kan inte se ut så här,behöver ett event som triggar denna, 
            //allt ska gå ifrån waiter som har lagt till en order och sen ska det rassla till :)
            
                while (OrderQue.Instance.Orders.Count > 0)
                {
                    Order orderToWork = OrderQue.Instance.Orders.Dequeue();
                    OnOrderWorkPrepared(orderToWork);
                }
            
        }
        protected virtual void OnOrderWorkPrepared(Order orderToProccess)
        {
            OrderWorkPrepared?.Invoke(this, new OrderEventArgs { Order = orderToProccess });
        }
    }
}
