using RestaurantDesignPatterns;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingThreads
{
    public class WorkDirector
    {
        public ChefThread[] ThreadsToWorkWith { get; set; } = new ChefThread[5];
        public static List<string> WorkOrdersRunned { get; set; } = new List<string>();
        public static ConcurrentQueue<ObjectToWorkON> WorkOrdersToExecute { get; set; } = new ConcurrentQueue<ObjectToWorkON>();
        public static List<bool> HasTheThreadBeenTerminated { get; set; } = new List<bool>();
        public void SetChefStatus()
        {
            for (int i = 0; i < ThreadsToWorkWith.Length; i++)
            {
                ThreadsToWorkWith[i] = new ChefThread();
            }
        }
        public void EveryBodyWork(string jobb)
        {
            for (int i = 0; i < ThreadsToWorkWith.Length; i++)
            {
                if (ThreadsToWorkWith[i].WorkStatus == RestaurantDesignPatterns.WorkStatus.Idle && WorkOrdersToExecute.Count > 0)
                {
                    ThreadsToWorkWith[i].InitiateWork();
                    Thread.Sleep(100);
                }
                
            }
        }
        public void PrintWorkOrdersNotManaged()
        {
            if (WorkOrdersRunned.Count > 0)
            {
                foreach (var item in WorkDirector.WorkOrdersRunned)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
