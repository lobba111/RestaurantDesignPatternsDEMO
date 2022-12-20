using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class DbTwo
    {
        public List<bool> GetSomeGabaBool { get; set; }
        public DbTwo()
        {
            GetSomeGabaBool = new List<bool> { false, true, false, true };
        }
        public List<bool> GetAll()
        {

            return GetSomeGabaBool;
        }
    }
}
