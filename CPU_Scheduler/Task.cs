using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    class Task
    {
        public Process process;
        public int timeslice;
        public ProcessBlock block;
    }
}
