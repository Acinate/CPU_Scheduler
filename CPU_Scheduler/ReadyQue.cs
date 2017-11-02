using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    class ReadyQue
    {
        public ReadyQue()
        {
            processes = new List<Process>();
        }
        public List<Process> processes;
        public void addProcess(Process p)
        {
            processes.Add(p);
        }
        public void removeProcess()
        {

        }
    }
}
