using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    public partial class Form1 : Form
    {
        public DataTable table;
        private List<Process> processes;
        private ReadyQue readyQue;
        public Form1()
        {
            InitializeComponent();
            // this.Height = Screen.PrimaryScreen.Bounds.Height;
            // this.Width = Screen.PrimaryScreen.Bounds.Width;
            processes = new List<Process>();
            readyQue = new ReadyQue();
            autoSizeColumnNames(); // Resize our grid component
            addPropertyNames(); // Add property names to columns so we can bind to them
            createTable(); // Create a data table object and add it to our data source
            dataGridView1.DataSource = bindingSource1; // Bind table data
            cyclePanel.Paint += new PaintEventHandler(cyclePanel_Paint); // Add OnPaint Event for Gantt chart
            readyQuePanel.Paint += new PaintEventHandler(readyQue_Paint); // Add OnPaint Event for readyque panel
            Process test = new Process()
            {
                id = 100,
                state = "Idle",
                priority = 5,
                runtime = 0,
                timeleft = 30000,
                block = new ProcessBlock() { brush_color = new SolidBrush(Color.FromArgb(100, Color.Green)), x_position = 0, y_position = 0, width = 10, height = readyQuePanel.Height }
            };
            Process test1 = new Process()
            {
                id = 200,
                state = "Idle",
                priority = 5,
                runtime = 0,
                timeleft = 30000,
                block = new ProcessBlock() { brush_color = new SolidBrush(Color.FromArgb(100, Color.Green)), x_position = 0, y_position = 0, width = 10, height = readyQuePanel.Height }
            };
            readyQue.addProcess(test);
            readyQue.addProcess(test1);
        }
        private void cyclePanel_Paint(object sender, PaintEventArgs e)
        {
            List<Process> updatedProcesses = new List<Process>();
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            // If panel is full, remove the first item :: Can add a while loop here in the future
            if (processes.Count > 1)
            {
                if (cyclePanel.Width < 2.0 * (processes[processes.Count - 2].block.x_position + 1 + processes[processes.Count - 2].block.width))
                {
                    processes.RemoveAt(0);
                }
            }
            // Calculate drawing properties for each Process object          
            for (int i=0;i<processes.Count;i++)
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
                current.block.width = 10;
                current.block.height = cyclePanel.Height;
                updatedProcesses.Add(current);
            }
            processes = updatedProcesses;
            // Paint each Process object to the screen
            foreach (Process process in processes) {
                e.Graphics.FillRectangle(process.block.brush_color, process.block.x_position, process.block.y_position, process.block.width,process.block.height);
            }
            Console.WriteLine("We are painting..");
        }
        private void readyQue_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            for (int i=0;i<readyQue.processes.Count;i++)
            {
                Process current = readyQue.processes[i];
                Process prev;
                if (i == 0)
                    current.block.x_position = 0;
                else
                {
                    prev = readyQue.processes[i - 1];
                    current.block.x_position = prev.block.x_position + 1 + prev.block.width;
                }
                current.block.width = 50;
                current.block.height = readyQuePanel.Height;
                current.block.draw_point = new PointF(current.block.x_position,(current.block.y_position/2));
                foreach (Process pro in readyQue.processes)
                {
                    e.Graphics.FillRectangle(pro.block.brush_color, pro.block.x_position, pro.block.y_position, pro.block.width, pro.block.height);
                    e.Graphics.DrawString(pro.id.ToString(), pro.block.font, pro.block.text_brush, pro.block.draw_point);
                }
            }
        }
        private void autoSizeColumnNames()
        {
            foreach (DataGridViewColumn v in dataGridView1.Columns) {
                v.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }
        private void addPropertyNames()
        {
            dataGridView1.Columns[0].DataPropertyName = "ProcessId";
            dataGridView1.Columns[1].DataPropertyName = "State";
            dataGridView1.Columns[2].DataPropertyName = "Priority";
            dataGridView1.Columns[3].DataPropertyName = "TimeLeft";
            dataGridView1.Columns[4].DataPropertyName = "Runtime";
        }
        private void createTable()
        {
            table = new DataTable();
            DataRow row = table.NewRow();
            DataColumn[] columns = new DataColumn[] { new DataColumn("ProcessId"), new DataColumn("State"), new DataColumn("Priority"), new DataColumn("Runtime"), new DataColumn("TimeLeft") };
            table.Columns.AddRange(columns);
            bindingSource1.DataSource = table.DefaultView;
        }
        private async void addProcess(int pid)
        {
            Random r = new Random();
            int rPriority = r.Next(0, 5);
            int rTimeleft = r.Next(1000, 60000);
            // Create process object
            Process p = new Process();
            p.id = pid;
            p.state = "Ready";
            p.priority = rPriority;
            p.timeleft = rTimeleft;
            p.runtime = 0;
            p.block = new ProcessBlock();
            // Add random block color
            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Black };
            Random ra = new Random();
            int rnum = ra.Next(0, 4);
            p.block.brush_color = new SolidBrush(Color.FromArgb(100, colors[rnum]));
            processes.Add(p);
            // Create datarow from process object
            DataRow row = table.NewRow();
            row["ProcessId"] = p.id;
            row["Priority"] = p.priority;
            row["State"] = p.state;
            row["Runtime"] = p.runtime;
            row["TimeLeft"] = p.timeleft;
            await Task.Factory.StartNew(() => table.Rows.Add(row));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            int indexOfLastId;
            try
            {
                indexOfLastId = int.Parse(table.Rows[table.Rows.Count - 1][0].ToString()) + 1;
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                indexOfLastId = 0;
            }
            addProcess(indexOfLastId);
            cyclePanel.Refresh();
            Console.WriteLine(cyclePanel.Width);
        }

        private async void simulate()
        {
            for (int i=0;i<1000;i++)
            {
                await Task.Factory.StartNew(() => addProcess(1337));
                Thread.Sleep(100);
                cyclePanel.Refresh();
            }
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            simulate();
        }
    }
}
