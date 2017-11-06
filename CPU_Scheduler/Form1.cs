using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    public partial class Form1 : Form
    {
        public DataTable table;
        private List<Process> processes;
        private CPU cpu;
        private bool running;
        public Form1()
        {
            InitializeComponent();
            processes = new List<Process>();
            cpu = new CPU(this);
            autoSizeColumnNames(); // Resize our grid component
            addPropertyNames(); // Add property names to columns so we can bind to them
            createTable(); // Create a data table object and add it to our data source
            dataGridView1.DataSource = bindingSource1; // Bind table data
            DoubleBuffered = true;
            cyclePanel.Paint += new PaintEventHandler(cyclePanel_Paint); // Add OnPaint Event for Gantt chart
            readyQuePanel.Paint += new PaintEventHandler(readyQue_Paint); // Add OnPaint Event for readyque panel
            // Adds double buffering to get rid of paint flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, cyclePanel, new object[] { true });
            // Adding Processes to ready que
        }
        private void cyclePanel_Paint(object sender, PaintEventArgs e)
        {
            cpu.paint(sender, e);
        }
        private void readyQue_Paint(object sender, PaintEventArgs e)
        {
            cpu.readyQue.paint(sender, e);
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
        private void addProcess(int pid)
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
            table.Rows.Add(row);
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
                if (running)
                {
                    addProcess(1337);
                    Thread.Sleep(100);
                    cyclePanel.Refresh();
                } else
                {
                    break;
                }
            }
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            cpu.readyQue.addProcesses(processes.ToArray());
            cpu.readyQue.run();
        }
    }
}
