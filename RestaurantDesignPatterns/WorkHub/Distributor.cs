using RestaurantDesignPatterns.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.WorkHub
{
    public class Distributor
    {
        //denna klass ska hantera och delegera allt jobb som kommer in
        //den ska också premunera på vad arbetaren gör och lyssna på när ett arbete är utfört
        public event EventHandler<EventArgs> DistributorChanged;
        public static int counter;
        
        
        public void OnOrderAdded(object source, OrderEventArgs eventArgs)
        {

            
            Console.WriteLine("Okej nu har vi fått in ett jobb hälsningar DISTIBUTOR");
            StartWork();
             
        }
        public void StartWork()
        {
            
            
            Console.WriteLine("Skickar jobb till kocken DISTIBUTOR");
            SendWorkToStart();
        }
        public void WorkDone(object source,WorkDoneEventArgs eventArgs)
        {
            counter++;
            OrderQue.Instance.RemoveOrder();
            Console.WriteLine($"{eventArgs.WorkDone} : NU ÄR VI I DISTRIBUTE OCH vi har fått ett medellande från kocken");
        }
        protected virtual void SendWorkToStart()
        {
            DistributorChanged?.Invoke(this, new EventArgs());
        }
    }
}
