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
        public DataTable processTable;
        public List<Process> processes;
        private CPU cpu;
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
            dataGridView1.Columns[2].DataPropertyName = "ArrivalTime";
            dataGridView1.Columns[3].DataPropertyName = "Priority";
            dataGridView1.Columns[4].DataPropertyName = "TimeLeft";
            dataGridView1.Columns[5].DataPropertyName = "Runtime";
            dataGridView1.Columns[6].DataPropertyName = "ContextSwitches";
        }
        private void createTable()
        {
            processTable = new DataTable();
            DataRow row = processTable.NewRow();
            DataColumn[] columns = new DataColumn[] { new DataColumn("ProcessId"), new DataColumn("State"), new DataColumn("ArrivalTime"), new DataColumn("Priority"), new DataColumn("Runtime"), new DataColumn("TimeLeft"), new DataColumn("ContextSwitches") };
            processTable.Columns.AddRange(columns);
            bindingSource1.DataSource = processTable.DefaultView;
            processTable.PrimaryKey = new DataColumn[] { processTable.Columns["ProcessId"] };
        }
        private void addProcess(int pid)
        {
            Random r = new Random();
            int rArrival = r.Next(0, 15);
            int rPriority = r.Next(0, 5);
            int rTimeleft = r.Next(10, 60);
            // Create process object
            Process p = new Process();
            p.id = pid;
            p.state = "Null";
            p.arrivalTime = rArrival;
            p.priority = rPriority;
            p.timeleft = rTimeleft;
            p.runtime = 0;
            p.contextSwitches = 0;
            p.block = new ProcessBlock();
            // Add random block color
            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Black };
            Random ra = new Random();
            int rnum = ra.Next(0, 4);
            p.block.brush_color = new SolidBrush(Color.FromArgb(100, colors[rnum]));
            // Add new generated process to list
            processes.Add(p);
            // Create datarow from process object
            DataRow row = processTable.NewRow();
            row["ProcessId"] = p.id;
            row["ArrivalTime"] = p.arrivalTime;
            row["Priority"] = p.priority;
            row["State"] = p.state;
            row["Runtime"] = p.runtime;
            row["TimeLeft"] = p.timeleft;
            row["ContextSwitches"] = p.contextSwitches;
            processTable.Rows.Add(row);
        }
        private void addProcessExact(Process p)
        {
            // Create datarow
            DataRow row = processTable.NewRow();
            row["ProcessId"] = p.id;
            row["ArrivalTime"] = p.arrivalTime;
            row["Priority"] = p.priority;
            row["State"] = p.state;
            row["Runtime"] = p.runtime;
            row["TimeLeft"] = p.timeleft;
            row["ContextSwitches"] = p.contextSwitches;
            processTable.Rows.Add(row);
        }
        public void updateProcess(Process p)
        {
            try
            {
                DataRow row = processTable.Rows.Find(p.id);
                row["ProcessId"] = p.id;
                row["ArrivalTime"] = p.arrivalTime;
                row["Priority"] = p.priority;
                row["State"] = p.state;
                row["Runtime"] = p.runtime;
                row["TimeLeft"] = p.timeleft;
                row["ContextSwitches"] = p.contextSwitches;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating process table.");
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            int indexOfLastId;
            try
            {
                indexOfLastId = int.Parse(processTable.Rows[processTable.Rows.Count - 1][0].ToString()) + 1;
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

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnSimulate.Enabled = false;
            cpu.readyQue.addProcesses(processes.ToArray());
            System.Threading.Tasks.Task.Factory.StartNew(()=> cpu.readyQue.run());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Resets all simulation data
            processes = new List<Process>();
            processTable.Clear();
            cpu.taskHistory = new List<Task>();
            cpu.readyQue.processes = new List<Process>();
            readyQuePanel.Refresh();
            cpu.readyQue.running = false;
            btnSimulate.Enabled = true;
            btnNew.Enabled = true;
            lblTimeRunning.Text = "0";
            lblReadyQueSize.Text = "0";
            lblTimeQuantum.Text = "0";
        }
    }
}
