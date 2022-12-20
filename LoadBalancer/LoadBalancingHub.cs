using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class LoadBalancingHub
    {
        Queue<HttpRequestMessage> QueForRequests { get; set; } = new Queue<HttpRequestMessage>();
        int RequestCounter = 0;
        public DbOne DbOne { get; set; } = new DbOne();//detta borde ju rimligen vara någon form av service, för att sedan gå till en gateway? som leder min fråga till rätt endpoint
        public DbTwo DbTwo { get; set; } = new DbTwo();
        public void AddRequests(HttpRequestMessage requsetToQue)
        {
            QueForRequests.Enqueue(requsetToQue);
        }
        /// <summary>
        /// antingen ska det var en Task som distrubieras eller ett meddelande till en service 
        /// </summary>
        /// <param name="requestMessage"></param>
        public void BalanceLoad(HttpRequestMessage requestMessage)
        {
            //här kommer en fråga in 
            //skicka frågan till varanan server,
            //jag behöver också kunna hantera så att jag kan skicka svaret på något sätt 
            //jag måste ju ta reda på vad det är för fråga också som skickas in ? 
            //async await ? 
            //jag tror inte att jag behöver ha koll på någon response, det borde rimligen tas omhand någon annan stanns eller
            //så vill ha denna funktionen som en policy
            string url = requestMessage.RequestUri.ToString();
            if (RequestCounter % 2 == 0 && PingServer.IsEndPointAlive(url,3))
            {
                DbOne.GetAll();
                RequestCounter++;
            }
            else if(RequestCounter % 2 != 0 && PingServer.IsEndPointAlive(url,3))
            {
                DbTwo.GetAll();
                RequestCounter++;
            }
            
        }
    }
}
