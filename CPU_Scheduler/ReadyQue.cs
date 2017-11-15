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
        CPU cpu;
        Form1 form;
        public List<Process> processes;
        public ReadyQue(Form1 form, CPU cpu)
        {
            this.form = form;
            this.cpu = cpu;
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
                    // Attempt to clear the ready que
                    form.processes = new List<Process>();
                    running = false;
                }
                else
                {
                    // Run the process for the allowed timeslice
                    cpu.runProcess(processes[0], 5000);
                }
                // Paints processes in ready que
                form.readyQuePanel.Refresh();
                // Allow the listview to update
                form.dataGridView1.Update();
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
                current.block.y_position = 0;
                current.block.width = 50;
                current.block.height = form.readyQuePanel.Height;
                current.block.draw_point = new PointF(current.block.x_position, (current.block.height / 2));
                processes[i] = current;
            }
            foreach (Process pro in processes)
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
        private bool running;
    }
}
