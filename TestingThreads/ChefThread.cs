using RestaurantDesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingThreads
{
    public class ChefThread
    {
        static int Counter = 1;
        protected Thread _thread;
        public WorkStatus WorkStatus {get;set;} = WorkStatus.Idle;
        public void InitiateWork()
        {
            ObjectToWorkON order;
            WorkDirector.WorkOrdersToExecute.TryDequeue(out order);
            this.WorkStatus = WorkStatus.Working;
            Console.WriteLine("Starta upp tråd");
            _thread = new Thread(new ThreadStart(Work)) { IsBackground = true};
            _thread.Start();
            
            Logger.LogInfo($"Works done : {Counter} | Time of start : {DateTime.Now} | Object worked on id : {order.Guid} | Thread that did the work {_thread.ManagedThreadId}\n");
            Counter++;
            
        }
        public void Work()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Jobbar {_thread.ManagedThreadId}");
                Thread.Sleep(100);
            }
            DoneWork();
            
        }
        public void DoneWork()
        {
            this.WorkStatus = WorkStatus.Idle;
            
            WorkDirector.WorkOrdersRunned.Add(Counter.ToString());
            Console.WriteLine($"Slutat jobba  skickar signal om det {_thread.ManagedThreadId}, Workstatus = {WorkStatus = WorkStatus.Idle}");
            
            _thread.Join(10);
            
           
            
        }
    }
}
