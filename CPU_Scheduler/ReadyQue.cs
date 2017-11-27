using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    class ReadyQue
    {
        CPU cpu;
        Form1 form;
        public List<Process> processes;
        public List<Process> readyProcesses;
        public bool running;
        public Stopwatch timer;
        public ReadyQue(Form1 form, CPU cpu)
        {
            this.form = form;
            this.cpu = cpu;
            processes = new List<Process>();
            readyProcesses = new List<Process>();
        }
        public void run()
        {
            // Calculate time quantum
            int quantum = 0;
            foreach (Process p in processes)
            {
                quantum += p.arrivalTime;
            }
            quantum /= processes.Count;
            if (form.lblTimeQuantum.InvokeRequired)
            {
                form.lblTimeQuantum.Invoke((MethodInvoker)delegate ()
               {
                   form.lblTimeQuantum.Text = quantum.ToString();
               });
            }
            timer = new Stopwatch();
            timer.Start();
            running = true;
            while (running)
            {
                // Update running time
                if (form.lblTimeRunning.InvokeRequired) {
                    form.lblTimeRunning.Invoke((MethodInvoker)delegate ()
                    {
                        form.lblTimeRunning.Text = (timer.ElapsedMilliseconds/1000).ToString();
                    });
                }
                // Update ready que size
                if (form.lblReadyQueSize.InvokeRequired)
                {
                    form.lblReadyQueSize.Invoke((MethodInvoker)delegate ()
                    {
                        form.lblReadyQueSize.Text = readyProcesses.Count.ToString();
                    });
                }
                // Add Processes to ready que when arrival time is passed
                foreach (Process process in processes)
                {
                    if (process.arrivalTime <= timer.ElapsedMilliseconds/1000)
                    {
                        if (!readyProcesses.Any(p => p.id == process.id))
                        {
                            // Run the process for the allowed timeslice
                            Console.WriteLine("Process: " + process.id + " Arrival Time: " + process.arrivalTime + " >= " + (timer.ElapsedMilliseconds / 1000).ToString());
                            readyProcesses.Add(process);
                        }
                    }
                }
                if (processes.Count == 0 && readyProcesses.Count == 0)
                {
                    // If no processes, CPU is idle
                    MessageBox.Show("Idle cpu");
                    // Attempt to clear the ready que
                    form.processes = new List<Process>();
                    running = false;
                    timer.Stop();
                }
                else
                {
                    if (readyProcesses.Count > 0)
                    {
                        // Run the process for the allowed timeslice
                        cpu.runProcess(readyProcesses[0], quantum);
                    }
                }
                if (form.readyQuePanel.InvokeRequired)
                {
                    form.readyQuePanel.Invoke((MethodInvoker)delegate ()
                    {
                        form.readyQuePanel.Refresh();
                    });
                } else
                {
                    form.readyQuePanel.Refresh();
                }
            }
        }
        public void paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            for (int i = 0; i < readyProcesses.Count; i++)
            {
                Process current = readyProcesses[i];
                Process prev;
                if (i == 0)
                    current.block.x_position = 0;
                else
                {
                    prev = readyProcesses[i - 1];
                    current.block.x_position = prev.block.x_position + 1 + prev.block.width;
                }
                current.block.y_position = 0;
                current.block.width = 50;
                current.block.height = form.readyQuePanel.Height;
                current.block.draw_point = new PointF(current.block.x_position, (current.block.height / 2));
                readyProcesses[i] = current;
            }
            foreach (Process pro in readyProcesses)
            {
                e.Graphics.FillRectangle(pro.block.brush_color, pro.block.x_position, pro.block.y_position, pro.block.width, pro.block.height);
                e.Graphics.DrawString(pro.id.ToString(), pro.block.font, pro.block.text_brush, pro.block.draw_point);
            }
        }
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
        public void removeProcess(int id)
        {
            processes.RemoveAt(id);
        }
    }
}
