using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer.FluentPolicyBuilder
{
    public abstract class PolicyBuilder
    {
        protected Wrapper wrapper;
        public PolicyBuilder()
        {
            wrapper = new Wrapper();
        }
        public Wrapper Build() => wrapper;
    }
}
