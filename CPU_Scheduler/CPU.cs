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
        public List<Task> taskHistory;
        public CPU(Form1 form)
        {
            this.form = form;
            readyQue = new ReadyQue(form, this);
            //deviceQue = new DeviceQue(form, this);
            taskHistory = new List<Task>();
        }
        public String status { get; set; }
        public void runProcess(Process process, int timeslice)
        {
            process.state = "Running";
            form.updateProcess(process);
            if (process.timeleft >= timeslice)
            {
                process.contextSwitches++;
                process.timeleft -= timeslice;
                process.runtime += timeslice;
            } else
            {
                process.runtime += process.timeleft;
                process.timeleft -= process.timeleft;
            }
            if (process.timeleft <= 0)
            {
                process.state = "Terminated";
                // If a process is finished running, remove it from ready que
                process.timeleft = 0;
                readyQue.processes.RemoveAll(p => p.id == process.id);
                readyQue.readyProcesses.RemoveAt(0);
                form.updateProcess(process);
            }
            // Process is currently running, freeze simulation for allocated timeslice
            Thread.Sleep(timeslice*100);
            // Remove 10ms from total_time_running to makeup for dispatcher latency
            readyQue.total_time_running += (timeslice*100);
            // Add quantum slice to simulation time
            readyQue.simulation_time += timeslice;
            if (process.timeleft > 0)
            {
                // If a process still needs more time, send to it to the back of the que
                readyQue.readyProcesses.Insert(readyQue.readyProcesses.Count, process);
                readyQue.readyProcesses.RemoveAt(0);
                // MessageBox.Show("Running process: " + process.id + ", time left: " + process.timeleft);
                process.state = "Ready";
                form.updateProcess(process);
            }
            ProcessBlock block = new ProcessBlock();
            block.brush_color = process.block.brush_color;
            block.width = 30;
            block.x_position = 0;
            block.y_position = 0;
            block.height = form.cyclePanel.Height;
            if (taskHistory.Count > 0)
            {
                Task prevTask = taskHistory[taskHistory.Count - 1];
                block.x_position = prevTask.block.x_position + 1 + prevTask.block.width;
            }
            Task task = new Task() { process = process, timeslice = timeslice, block = block };
            taskHistory.Add(task);
            // Paints the cpu task in cyclePanel
            if (form.cyclePanel.InvokeRequired)
            {
                form.cyclePanel.Invoke((MethodInvoker)delegate ()
                {
                    form.cyclePanel.Refresh();
                });
            } else
            {
                form.cyclePanel.Refresh();
            }
            System.Threading.Tasks.Task.Factory.StartNew(()=>System.Threading.Tasks.Task.Delay(10));
        }
        public void paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            // If panel is full, remove the first item :: Can add a while loop here in the future
            if (taskHistory.Count > 1)
            {
                if (form.cyclePanel.Width < (taskHistory[taskHistory.Count - 2].block.x_position + 1 + taskHistory[taskHistory.Count - 2].block.width))
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
        }
    }
}
