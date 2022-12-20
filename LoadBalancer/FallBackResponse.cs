using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class FallBackResponse
    {
        //metod för vårat fallback medellande som skickas som en response 
        public HttpResponseMessage SetFallBackMessage(string standardFallBackResponeMessage)
        {
            return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable) { Content = new StringContent(standardFallBackResponeMessage) };
        }
    }
}
