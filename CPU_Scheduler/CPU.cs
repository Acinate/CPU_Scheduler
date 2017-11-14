using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    class CPU
    {
        public ReadyQue readyQue;
        private Form1 form;
        private List<Task> taskHistory;
        public CPU(Form1 form)
        {
            this.form = form;
            readyQue = new ReadyQue(form, this);
            //deviceQue = new DeviceQue(form, this);
            taskHistory = new List<Task>();
        }
        public String status { get; set; }
        public void runProcess(Process process)
        {
            process.timeleft -= 5000;
            process.runtime += 5000;
            if (process.timeleft <= 0)
            {
                // If a process is finished running, remove it from ready que
                MessageBox.Show(process.id + " has finished running");
                readyQue.processes.RemoveAt(0);
            }
            else
            {
                // If a process still needs more time, send to it to the back of the que
                readyQue.processes.Insert(readyQue.processes.Count, process);
                readyQue.processes.RemoveAt(0);
                // MessageBox.Show("Running process: " + process.id + ", time left: " + process.timeleft);
                Thread.Sleep(500);
                ProcessBlock block = new ProcessBlock();
                block.brush_color = process.block.brush_color;
                block.width = 10;
                block.x_position = 0;
                block.y_position = 0;
                block.height = form.cyclePanel.Height;
                if (taskHistory.Count > 0)
                {
                    Task prevTask = taskHistory[taskHistory.Count - 1];
                    block.x_position = prevTask.block.x_position + 1 + prevTask.block.width;
                }
                Task task = new Task() { process = process, timeslice = 5000, block = block };
                taskHistory.Add(task);
                form.cyclePanel.Refresh(); // Paints the cpu task in cyclePanel
            }
        }
        public void paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            // If panel is full, remove the first item :: Can add a while loop here in the future
            if (taskHistory.Count > 1)
            {
                if (form.cyclePanel.Width < 2.0 * (taskHistory[taskHistory.Count - 2].block.x_position + 1 + taskHistory[taskHistory.Count - 2].block.width))
                {
                    taskHistory.RemoveAt(0);
                }
            }
            // Calculate paint properties
            for (int i=0;i<taskHistory.Count;i++)
            {
                Task current = taskHistory[i];
                if (i == 0)
                {
                    current.block.x_position = 0;
                } else
                {
                    Task prev = taskHistory[i - 1];
                    current.block.x_position = prev.block.x_position + 1 + prev.block.width;
                }
                current.block.draw_point = new PointF(current.block.x_position, (current.block.height)/2);
                taskHistory[i] = current;
            }
            // Paint each Process object to the screen
            foreach (Task task in taskHistory)
            {
                e.Graphics.FillRectangle(task.block.brush_color, task.block.x_position, task.block.y_position, task.block.width, task.block.height);
                e.Graphics.DrawString(task.process.id.ToString(), task.block.font, task.block.text_brush, task.block.draw_point);
            }
            Console.WriteLine("We are painting..");
        }
    }
}
