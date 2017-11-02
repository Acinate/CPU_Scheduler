using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    class Process
    {
        public int id { get; set; }
        public string state { get; set; }
        public long runtime { get; set; } // in milliseconds
        public int priority { get; set; }
        public int timeleft { get; set; }
    }
}
