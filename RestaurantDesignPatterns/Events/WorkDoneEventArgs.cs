using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesignPatterns.Events
{
    public class WorkDoneEventArgs : EventArgs
    {
        public string WorkDone { get; set; }
    }
}
