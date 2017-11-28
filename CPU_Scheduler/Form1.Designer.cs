namespace CPU_Scheduler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAvgContextSwitch = new System.Windows.Forms.Label();
            this.lblJobsCompleted = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSimulationTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCpuUtilization = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAvgTurnaround = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAverageThroughput = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTimeQuantum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReadyQueSize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTimeRunning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTaskHistory = new System.Windows.Forms.Label();
            this.lblReadyQue = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cyclePanel = new System.Windows.Forms.Panel();
            this.readyQuePanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Runtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextSwitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStarted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeEnded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblTaskHistory);
            this.splitContainer1.Panel2.Controls.Add(this.lblReadyQue);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(994, 693);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(6, 371);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 316);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSimulate);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 354);
            this.panel1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 9);
            this.btnNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 44);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Process";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulate.Location = new System.Drawing.Point(6, 65);
            this.btnSimulate.Margin = new System.Windows.Forms.Padding(6);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(63, 44);
            this.btnSimulate.TabIndex = 1;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(5, 121);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 44);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAvgContextSwitch);
            this.groupBox1.Controls.Add(this.lblJobsCompleted);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblSimulationTime);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblCpuUtilization);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblAvgTurnaround);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblAverageThroughput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblTimeQuantum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblReadyQueSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTimeRunning);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 171);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Stats";
            // 
            // lblAvgContextSwitch
            // 
            this.lblAvgContextSwitch.AutoSize = true;
            this.lblAvgContextSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgContextSwitch.Location = new System.Drawing.Point(434, 27);
            this.lblAvgContextSwitch.Name = "lblAvgContextSwitch";
            this.lblAvgContextSwitch.Size = new System.Drawing.Size(39, 42);
            this.lblAvgContextSwitch.TabIndex = 8;
            this.lblAvgContextSwitch.Text = "0";
            // 
            // lblJobsCompleted
            // 
            this.lblJobsCompleted.AutoSize = true;
            this.lblJobsCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobsCompleted.Location = new System.Drawing.Point(732, 111);
            this.lblJobsCompleted.Name = "lblJobsCompleted";
            this.lblJobsCompleted.Size = new System.Drawing.Size(39, 42);
            this.lblJobsCompleted.TabIndex = 17;
            this.lblJobsCompleted.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(571, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(298, 42);
            this.label15.TabIndex = 16;
            this.label15.Text = "Jobs Completed:";
            // 
            // lblSimulationTime
            // 
            this.lblSimulationTime.AutoSize = true;
            this.lblSimulationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimulationTime.Location = new System.Drawing.Point(149, 69);
            this.lblSimulationTime.Name = "lblSimulationTime";
            this.lblSimulationTime.Size = new System.Drawing.Size(164, 42);
            this.lblSimulationTime.TabIndex = 15;
            this.lblSimulationTime.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(286, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(279, 42);
            this.label13.TabIndex = 14;
            this.label13.Text = "Avg Ctx Switch:";
            // 
            // lblCpuUtilization
            // 
            this.lblCpuUtilization.AutoSize = true;
            this.lblCpuUtilization.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpuUtilization.Location = new System.Drawing.Point(732, 27);
            this.lblCpuUtilization.Name = "lblCpuUtilization";
            this.lblCpuUtilization.Size = new System.Drawing.Size(72, 42);
            this.lblCpuUtilization.TabIndex = 13;
            this.lblCpuUtilization.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(571, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 42);
            this.label4.TabIndex = 6;
            this.label4.Text = "CPU Utilization:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 42);
            this.label11.TabIndex = 12;
            this.label11.Text = "Simulation Time:";
            // 
            // lblAvgTurnaround
            // 
            this.lblAvgTurnaround.AutoSize = true;
            this.lblAvgTurnaround.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgTurnaround.Location = new System.Drawing.Point(434, 111);
            this.lblAvgTurnaround.Name = "lblAvgTurnaround";
            this.lblAvgTurnaround.Size = new System.Drawing.Size(39, 42);
            this.lblAvgTurnaround.TabIndex = 11;
            this.lblAvgTurnaround.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(278, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 42);
            this.label9.TabIndex = 10;
            this.label9.Text = "Avg Turnaround:";
            // 
            // lblAverageThroughput
            // 
            this.lblAverageThroughput.AutoSize = true;
            this.lblAverageThroughput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageThroughput.Location = new System.Drawing.Point(434, 69);
            this.lblAverageThroughput.Name = "lblAverageThroughput";
            this.lblAverageThroughput.Size = new System.Drawing.Size(39, 42);
            this.lblAverageThroughput.TabIndex = 9;
            this.lblAverageThroughput.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(278, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 42);
            this.label7.TabIndex = 8;
            this.label7.Text = "Avg Throughput:";
            // 
            // lblTimeQuantum
            // 
            this.lblTimeQuantum.AutoSize = true;
            this.lblTimeQuantum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeQuantum.Location = new System.Drawing.Point(149, 111);
            this.lblTimeQuantum.Name = "lblTimeQuantum";
            this.lblTimeQuantum.Size = new System.Drawing.Size(39, 42);
            this.lblTimeQuantum.TabIndex = 5;
            this.lblTimeQuantum.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 42);
            this.label5.TabIndex = 4;
            this.label5.Text = "Time Quantum:";
            // 
            // lblReadyQueSize
            // 
            this.lblReadyQueSize.AutoSize = true;
            this.lblReadyQueSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadyQueSize.Location = new System.Drawing.Point(731, 69);
            this.lblReadyQueSize.Name = "lblReadyQueSize";
            this.lblReadyQueSize.Size = new System.Drawing.Size(39, 42);
            this.lblReadyQueSize.TabIndex = 3;
            this.lblReadyQueSize.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(571, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "# Ready Que:";
            // 
            // lblTimeRunning
            // 
            this.lblTimeRunning.AutoSize = true;
            this.lblTimeRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRunning.Location = new System.Drawing.Point(149, 27);
            this.lblTimeRunning.Name = "lblTimeRunning";
            this.lblTimeRunning.Size = new System.Drawing.Size(164, 42);
            this.lblTimeRunning.TabIndex = 1;
            this.lblTimeRunning.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Running Time:";
            // 
            // lblTaskHistory
            // 
            this.lblTaskHistory.AutoSize = true;
            this.lblTaskHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskHistory.Location = new System.Drawing.Point(-7, 545);
            this.lblTaskHistory.Name = "lblTaskHistory";
            this.lblTaskHistory.Size = new System.Drawing.Size(302, 55);
            this.lblTaskHistory.TabIndex = 4;
            this.lblTaskHistory.Text = "Task History";
            // 
            // lblReadyQue
            // 
            this.lblReadyQue.AutoSize = true;
            this.lblReadyQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadyQue.Location = new System.Drawing.Point(598, 545);
            this.lblReadyQue.Name = "lblReadyQue";
            this.lblReadyQue.Size = new System.Drawing.Size(277, 55);
            this.lblReadyQue.TabIndex = 3;
            this.lblReadyQue.Text = "Ready Que";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cyclePanel);
            this.flowLayoutPanel1.Controls.Add(this.readyQuePanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 597);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(899, 97);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // cyclePanel
            // 
            this.cyclePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cyclePanel.AutoScroll = true;
            this.cyclePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cyclePanel.Location = new System.Drawing.Point(3, 6);
            this.cyclePanel.Name = "cyclePanel";
            this.cyclePanel.Size = new System.Drawing.Size(586, 85);
            this.cyclePanel.TabIndex = 0;
            // 
            // readyQuePanel
            // 
            this.readyQuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.readyQuePanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.readyQuePanel.Location = new System.Drawing.Point(595, 3);
            this.readyQuePanel.Name = "readyQuePanel";
            this.readyQuePanel.Size = new System.Drawing.Size(301, 91);
            this.readyQuePanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessId,
            this.State,
            this.ArrivalTime,
            this.Priority,
            this.TimeLeft,
            this.Runtime,
            this.ContextSwitches,
            this.TimeStarted,
            this.TimeEnded});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(20, 6);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.Size = new System.Drawing.Size(850, 313);
            this.dataGridView1.TabIndex = 0;
            // 
            // ProcessId
            // 
            this.ProcessId.HeaderText = "PID";
            this.ProcessId.Name = "ProcessId";
            // 
            // State
            // 
            this.State.HeaderText = "Process State";
            this.State.Name = "State";
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.HeaderText = "Arrival Time";
            this.ArrivalTime.Name = "ArrivalTime";
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TimeLeft.HeaderText = "Time Left";
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Width = 135;
            // 
            // Runtime
            // 
            this.Runtime.HeaderText = "Time Ran";
            this.Runtime.Name = "Runtime";
            // 
            // ContextSwitches
            // 
            this.ContextSwitches.HeaderText = "Switches";
            this.ContextSwitches.Name = "ContextSwitches";
            // 
            // TimeStarted
            // 
            this.TimeStarted.HeaderText = "Time Started";
            this.TimeStarted.Name = "TimeStarted";
            // 
            // TimeEnded
            // 
            this.TimeEnded.HeaderText = "Time Ended";
            this.TimeEnded.Name = "TimeEnded";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 693);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Round Robin Scheduling Algorithm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.Panel readyQuePanel;
        public System.Windows.Forms.Panel cyclePanel;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTaskHistory;
        private System.Windows.Forms.Label lblReadyQue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTimeRunning;
        public System.Windows.Forms.Label lblReadyQueSize;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblTimeQuantum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblAvgTurnaround;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblAverageThroughput;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblJobsCompleted;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lblSimulationTime;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblCpuUtilization;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblAvgContextSwitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Runtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContextSwitches;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStarted;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeEnded;
    }
}

