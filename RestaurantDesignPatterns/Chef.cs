using RestaurantDesignPatterns.Events;
using RestaurantDesignPatterns.WorkHub;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns
{
    public class Chef
    {
        protected Thread _thread;
        public WorkStatus WorkStatus = WorkStatus.Idle;
        public event EventHandler<WorkDoneEventArgs> DoneEvent;
       
        private Order OrderToWorkOn { get; set; }
        
        //här bheöver jag fixa så att vi tittar så att jag kanske har en array med kockar
        //alla dom har sin status och tråd
        //är dom lediga för att ta emot Work så gör dom det annars inte
        public void SendWorkToStart(object source, EventArgs eventArgs) 
        {      
                CancellationTokenSource cts = new CancellationTokenSource();
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), cts.Token);
                cts.Cancel();
                cts.Dispose();      
        }
        public void DoWork(object obj) 
        {
            var orderToPrepare = OrderQue.Instance.Orders.Peek();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Okej nu jobbar jag på {orderToPrepare.MenuItem.Dishname} {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            }
            
            DoneWork(obj);
        }
        public void DoneWork(object obj) 
        {
            Console.WriteLine($"Nu är vi i donework och jag skickar en signalt tillbaka till distrubutören att jag är färdig {Thread.CurrentThread.ManagedThreadId}");
           OnWorkDone();
            CancellationToken token = (CancellationToken)obj;
        }
        protected virtual void OnWorkDone()
        {            
            DoneEvent?.Invoke(this, new WorkDoneEventArgs {WorkDone = $"Nu har jag jobbat klart {Thread.CurrentThread.ManagedThreadId}"}); 
        }
    }
}
