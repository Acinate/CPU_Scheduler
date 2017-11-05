using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    class ReadyQue
    {
        public ReadyQue()
        {
            processes = new List<Process>();
        }
        public void run()
        {
            running = true;
            while (running)
            {
                if (processes.Count == 0)
                {
                    // If no processes, CPU is idle
                    MessageBox.Show("Idle cpu");
                }
                else
                {
                    // Run the process for the allowed timeslice
                    processes[0].timeleft -= 5000;
                    processes[0].runtime += 5000;
                    if (processes[0].timeleft <= 0)
                    {
                        // If a process is finished running, remove it from ready que
                        MessageBox.Show(processes[0].id + " has finished running");
                        processes.RemoveAt(0);
                    }
                    else
                    {
                        // If a process still needs more time, send to it to the back of the que
                        MessageBox.Show("Requeing process: "+processes[0].id+", time left: "+processes[0].timeleft);
                        processes.Insert(processes.Count, processes[0]);
                        processes.RemoveAt(0);
                    }
                }
            }
        }
        public List<Process> processes;
        public void addProcess(Process p)
        {
            processes.Add(p);
        }
        public void removeProcess()
        {

        }
        private bool running;
    }
}
