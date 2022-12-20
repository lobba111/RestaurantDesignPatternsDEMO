using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    /// <summary>
    /// vore ju bra om servern är online, så vi kan skicka frågot till den
    /// Här skulle ju kanske fluentbuilder vara ett sätta att länka ihop allt
    /// pinga, vid svar, skicka fråga via load balancer
    /// </summary>
    internal static class PingServer
    {
        public static bool IsEndPointAlive(string hostName,int howManyRetrys)
        {
            var url = new Uri(hostName);
            var apiAdress = url.Host;
            Ping ping = new Ping();
            PingReply result = ping.Send(apiAdress);
            Console.WriteLine(result.Address.ToString());
            Console.WriteLine(result.RoundtripTime);
            Console.WriteLine(result.Buffer.Length);
            if (result.Status == IPStatus.Success)
            {
                //FallBackResponse.SetFallBackMessage("The service cannot be reached right now");
                return true;
            }
            else return RetryOnPingFails(hostName,howManyRetrys);
        }
        /// <summary>
        /// DENNA METOD SKA BO I EN HELT EGEN KLASS SOM EN RETRY POLICY
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="howManyRetrys"></param>
        /// <returns></returns>
        public static bool RetryOnPingFails(string hostName,int howManyRetrys)
        {
            int counterOfRetrys = howManyRetrys;
            int increment = 1;
            TimeSpan retryTime = TimeSpan.FromSeconds(1);
            while (counterOfRetrys != 0)
            {                
                var url = new Uri(hostName);
                var apiAdress = url.Host;
                Ping ping = new Ping();
                PingReply result = ping.Send(apiAdress);
                if (result.Status == IPStatus.Success)
                {
                    return true;                   
                }
                else
                {
                    Thread.Sleep(retryTime * increment);
                    counterOfRetrys--;
                    increment++;
                }
            }
            //FallBackResponse.SetFallBackMessage("The service cannot be reached right now");//false i detta fallet innebär att vi inte kommer åt den service vi vill, och vi behöver ha en fallback 
            return false;
        }
    }
}
