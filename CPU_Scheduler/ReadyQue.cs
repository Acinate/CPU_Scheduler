using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    class ReadyQue
    {
        Form1 form;
        public ReadyQue(Form1 form)
        {
            this.form = form;
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
                form.readyQuePanel.Refresh(); // This is what paints our process information
            }
        }
        public void paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            for (int i = 0; i < processes.Count; i++)
            {
                Process current = processes[i];
                Process prev;
                if (i == 0)
                    current.block.x_position = 0;
                else
                {
                    prev = processes[i - 1];
                    current.block.x_position = prev.block.x_position + 1 + prev.block.width;
                }
                current.block.width = 50;
                current.block.height = form.readyQuePanel.Height;
                current.block.draw_point = new PointF(current.block.x_position, (current.block.y_position / 2));
                foreach (Process pro in processes)
                {
                    e.Graphics.FillRectangle(pro.block.brush_color, pro.block.x_position, pro.block.y_position, pro.block.width, pro.block.height);
                    e.Graphics.DrawString(pro.id.ToString(), pro.block.font, pro.block.text_brush, pro.block.draw_point);
                }
            }
        }
        public List<Process> processes;
        public void addProcess(Process p)
        {
            processes.Add(p);
        }
        public void addProcesses(Process[] processes)
        {
            foreach (Process p in processes)
            {
                addProcess(p);
            }
        } 
        public void removeProcess()
        {

        }
        private bool running;
    }
}
