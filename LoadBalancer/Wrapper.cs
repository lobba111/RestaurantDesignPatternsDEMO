using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class Wrapper
    {
        /// <summary>
        /// HÄR FÅR JAG LÄGGA TILL MINA POLICYS VART EFTER ATT DOM BLIR KLARA
        /// JAG BEHÖVER JU TÄNKA UT EXAKT I VILKEN kedja som detta ska funka i och hur fan 
        /// jag får ihop det med metoder som skall köras, 
        /// men starskottet för hela kedjan borde rimligen vara att en httprequest kommer in och sedan 
        /// triggas allt igång
        /// vilket gör att jag antagligen kommer att få ändra lite i mina metoder och 
        /// hela min struktur?
        /// </summary>
        public HttpResponseMessage _fallBackResponse;
        public Wrapper SetFallBackRespone(string fallBackResponseMessage) 
        {
            var buffer = new FallBackResponse();
            _fallBackResponse = buffer.SetFallBackMessage(fallBackResponseMessage);
            return this;
        }
        
    }
}
