using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    public partial class Form1 : Form
    {
        public DataTable table;
        private List<Process> processes;
        public Form1()
        {
            InitializeComponent();
            processes = new List<Process>();
            autoSizeColumnNames(); // Resize our grid component
            addPropertyNames(); // Add property names to columns so we can bind to them
            createTable(); // Create a data table object and add it to our data source
            dataGridView1.DataSource = bindingSource1; // Bind table data
            cyclePanel.Paint += new PaintEventHandler(cyclePanel_Paint); // Add a OnPaint Event to form1
        }
        private void cyclePanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            // Calculate drawing properties for each Process object
          
            for (int i=0;i<processes.Count;i++)
            {
                if (i == 0)
                {
                    processes[i].block.x_position = 0;
                    processes[i].block.y_position = 0;
                    processes[i].block.width = 10;
                    processes[i].block.height = cyclePanel.Height;
                }
                else
                {
                    processes[i].block.x_position = processes[i-1].block.x_position + processes[i-1].block.width+1;
                    processes[i].block.y_position = 0;
                    processes[i].block.width = 5;
                    processes[i].block.height = cyclePanel.Height;
                }
            }
            foreach (Process process in processes) {
                e.Graphics.FillRectangle(process.block.brush_color, process.block.x_position, process.block.y_position, process.block.width,process.block.height);
            }
            Console.WriteLine("We are painting..");
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
            Process p = new Process();
            p.id = pid;
            p.state = "Ready";
            p.priority = rPriority;
            p.timeleft = rTimeleft;
            p.runtime = 0;
            p.block = new ProcessBlock();
            // Add block color
            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Black };
            Random ra = new Random();
            int rnum = ra.Next(0, 4);
            p.block.brush_color = new SolidBrush(Color.FromArgb(100, colors[rnum]));
            processes.Add(p);

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
        }
    }
}
