using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer.FluentPolicyBuilder
{
    public class FallBackPolicyBuilder<T>: PolicyBuilder where T :  FallBackPolicyBuilder<T>
    {
        public T SetFallBackPolicy(string fallBackMessage)
        {
            var buffer = new FallBackResponse();
            wrapper._fallBackResponse = buffer.SetFallBackMessage(fallBackMessage);
            return (T)this;
        }
    }
}
