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
        public int simulation_time;
        public int total_time_running;
        public double cpu_utilization;
        public int processes_completed;
        private int throughput;
        private int jobs_completed;
        public ReadyQue(Form1 form, CPU cpu)
        {
            this.form = form;
            this.cpu = cpu;
            processes = new List<Process>();
            readyProcesses = new List<Process>();
        }
        public void run()
        {
            simulation_time = 0;
            total_time_running = 0;
            cpu_utilization = 0;
            jobs_completed = 0;
            throughput = 0;
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
                // Update simulation time
                if (form.InvokeRequired)
                {
                    form.lblTimeRunning.Invoke((MethodInvoker)delegate ()
                   {
                       form.lblSimulationTime.Text = simulation_time.ToString();
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
                // Calculate average context switch
                int avg_context_switch = 0;
                int avg_context_switch_counter = 0;
                for (int i=0;i<form.dataGridView1.Rows.Count-1;i++)
                {
                    if (int.Parse(form.dataGridView1["ContextSwitches", i].Value.ToString())>0)
                    {
                        avg_context_switch += int.Parse(form.dataGridView1["ContextSwitches", i].Value.ToString());
                        avg_context_switch_counter++;
                    }
                }
                if (form.lblAvgContextSwitch.InvokeRequired)
                {
                    form.lblAvgContextSwitch.Invoke((MethodInvoker)delegate ()
                   {
                       if (avg_context_switch_counter>0)
                        form.lblAvgContextSwitch.Text = (avg_context_switch / avg_context_switch_counter).ToString();
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
                            // Console.WriteLine("Process: " + process.id + " Arrival Time: " + process.arrivalTime + " >= " + (timer.ElapsedMilliseconds / 1000).ToString());
                            process.timeStarted = simulation_time;
                            readyProcesses.Add(process);
                        }
                    }
                }
                // Check if there are still processes left to run
                if (processes.Count == 0 && readyProcesses.Count == 0)
                {
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
                        jobs_completed++;
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
                // Calculate average throughput
                if (processes_completed > 0)
                throughput = (simulation_time / processes_completed);
                // Update Throughput
                if (form.lblAverageThroughput.InvokeRequired)
                {
                    form.lblAverageThroughput.Invoke((MethodInvoker)delegate ()
                    {
                        form.lblAverageThroughput.Text = throughput.ToString();
                    });
                }
                // Calculate average turnaround
                int average_turnaround = 0;
                int average_turnaround_counter = 0;
                for (int i = 0; i< form.dataGridView1.Rows.Count-1; i++)
                {
                    if (int.Parse(form.dataGridView1["TimeEnded", i].Value.ToString()) > 0)
                    {
                        average_turnaround += int.Parse(form.dataGridView1["TimeEnded", i].Value.ToString()) - int.Parse(form.dataGridView1["TimeStarted", i].Value.ToString()); ;
                        average_turnaround_counter++;
                    }
                }
                if (average_turnaround_counter>0)
                average_turnaround /= average_turnaround_counter;
                // Display average turnaround
                if (form.lblAvgTurnaround.InvokeRequired)
                {
                   form.lblAvgTurnaround.Invoke((MethodInvoker)delegate ()
                   {
                       form.lblAvgTurnaround.Text = average_turnaround.ToString();
                   });
                }
                // Calculate CPU Utilization
                if (total_time_running>0)
                cpu_utilization = Math.Round((double)(100-(timer.ElapsedMilliseconds/total_time_running)),2);
                // Update CPU Utilization
                if (form.lblCpuUtilization.InvokeRequired)
                {
                    form.lblCpuUtilization.Invoke((MethodInvoker)delegate ()
                   {
                       form.lblCpuUtilization.Text = cpu_utilization + "%";
                   });
                }
                // Update jobs completed
                if (form.lblJobsCompleted.InvokeRequired)
                {
                    form.lblJobsCompleted.Invoke((MethodInvoker)delegate ()
                   {
                       form.lblJobsCompleted.Text = jobs_completed.ToString();
                   });
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
