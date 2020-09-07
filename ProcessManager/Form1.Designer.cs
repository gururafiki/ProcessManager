namespace ProcessManager
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
            this.btnFIFO = new System.Windows.Forms.Button();
            this.progressBarTasksDone = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.efficiency = new System.Windows.Forms.TextBox();
            this.realEfficiency = new System.Windows.Forms.TextBox();
            this.taskProbability = new System.Windows.Forms.TextBox();
            this.minOperationsPerTask = new System.Windows.Forms.TextBox();
            this.maxOperationsPerTask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.processorProbability = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalTasksDone = new System.Windows.Forms.TextBox();
            this.totalOperationsDone = new System.Windows.Forms.TextBox();
            this.btnSheduler = new System.Windows.Forms.Button();
            this.btnWorkingSheduler = new System.Windows.Forms.Button();
            this.btnOptimalWorkingSheduler = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countTasksDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countOperationsDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFIFO
            // 
            this.btnFIFO.Location = new System.Drawing.Point(9, 124);
            this.btnFIFO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFIFO.Name = "btnFIFO";
            this.btnFIFO.Size = new System.Drawing.Size(51, 49);
            this.btnFIFO.TabIndex = 0;
            this.btnFIFO.Text = "FIFO";
            this.btnFIFO.UseVisualStyleBackColor = false;
            this.btnFIFO.Click += new System.EventHandler(this.btnFIFO_Click);
            // 
            // progressBarTasksDone
            // 
            this.progressBarTasksDone.Location = new System.Drawing.Point(288, 124);
            this.progressBarTasksDone.Maximum = 9;
            this.progressBarTasksDone.Name = "progressBarTasksDone";
            this.progressBarTasksDone.Size = new System.Drawing.Size(278, 50);
            this.progressBarTasksDone.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.state,
            this.countTasksDone,
            this.type,
            this.speed,
            this.countOperationsDone});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(9, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(557, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Efficiency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Real efficiency:";
            // 
            // efficiency
            // 
            this.efficiency.Location = new System.Drawing.Point(501, 62);
            this.efficiency.Name = "efficiency";
            this.efficiency.Size = new System.Drawing.Size(39, 20);
            this.efficiency.TabIndex = 5;
            // 
            // realEfficiency
            // 
            this.realEfficiency.Location = new System.Drawing.Point(501, 87);
            this.realEfficiency.Name = "realEfficiency";
            this.realEfficiency.Size = new System.Drawing.Size(39, 20);
            this.realEfficiency.TabIndex = 6;
            // 
            // taskProbability
            // 
            this.taskProbability.Location = new System.Drawing.Point(501, 8);
            this.taskProbability.Name = "taskProbability";
            this.taskProbability.Size = new System.Drawing.Size(39, 20);
            this.taskProbability.TabIndex = 7;
            this.taskProbability.Text = "30";
            // 
            // minOperationsPerTask
            // 
            this.minOperationsPerTask.Location = new System.Drawing.Point(132, 9);
            this.minOperationsPerTask.Name = "minOperationsPerTask";
            this.minOperationsPerTask.Size = new System.Drawing.Size(87, 20);
            this.minOperationsPerTask.TabIndex = 8;
            this.minOperationsPerTask.Text = "2000";
            // 
            // maxOperationsPerTask
            // 
            this.maxOperationsPerTask.Location = new System.Drawing.Point(132, 36);
            this.maxOperationsPerTask.Name = "maxOperationsPerTask";
            this.maxOperationsPerTask.Size = new System.Drawing.Size(87, 20);
            this.maxOperationsPerTask.TabIndex = 9;
            this.maxOperationsPerTask.Text = "19000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max operations per task:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min operations per task:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Task emergence probability:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Processor emergence probability:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(546, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "%";
            // 
            // processorProbability
            // 
            this.processorProbability.Location = new System.Drawing.Point(501, 36);
            this.processorProbability.Name = "processorProbability";
            this.processorProbability.Size = new System.Drawing.Size(39, 20);
            this.processorProbability.TabIndex = 18;
            this.processorProbability.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Total tasks done:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Total operations done:";
            // 
            // totalTasksDone
            // 
            this.totalTasksDone.Location = new System.Drawing.Point(132, 64);
            this.totalTasksDone.Name = "totalTasksDone";
            this.totalTasksDone.Size = new System.Drawing.Size(87, 20);
            this.totalTasksDone.TabIndex = 21;
            // 
            // totalOperationsDone
            // 
            this.totalOperationsDone.Location = new System.Drawing.Point(132, 90);
            this.totalOperationsDone.Name = "totalOperationsDone";
            this.totalOperationsDone.Size = new System.Drawing.Size(87, 20);
            this.totalOperationsDone.TabIndex = 22;
            // 
            // btnSheduler
            // 
            this.btnSheduler.Location = new System.Drawing.Point(66, 124);
            this.btnSheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSheduler.Name = "btnSheduler";
            this.btnSheduler.Size = new System.Drawing.Size(60, 50);
            this.btnSheduler.TabIndex = 23;
            this.btnSheduler.Text = "Sheduler";
            this.btnSheduler.UseVisualStyleBackColor = false;
            this.btnSheduler.Click += new System.EventHandler(this.btnSheduler_Click);
            // 
            // btnWorkingSheduler
            // 
            this.btnWorkingSheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWorkingSheduler.Location = new System.Drawing.Point(132, 124);
            this.btnWorkingSheduler.Name = "btnWorkingSheduler";
            this.btnWorkingSheduler.Size = new System.Drawing.Size(68, 49);
            this.btnWorkingSheduler.TabIndex = 24;
            this.btnWorkingSheduler.Text = "Working Sheduler";
            this.btnWorkingSheduler.UseVisualStyleBackColor = false;
            this.btnWorkingSheduler.Click += new System.EventHandler(this.btnWorkingSheduler_Click);
            // 
            // btnOptimalWorkingSheduler
            // 
            this.btnOptimalWorkingSheduler.Location = new System.Drawing.Point(206, 124);
            this.btnOptimalWorkingSheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptimalWorkingSheduler.Name = "btnOptimalWorkingSheduler";
            this.btnOptimalWorkingSheduler.Size = new System.Drawing.Size(76, 49);
            this.btnOptimalWorkingSheduler.TabIndex = 25;
            this.btnOptimalWorkingSheduler.Text = "Optimal Working Sheduler";
            this.btnOptimalWorkingSheduler.UseVisualStyleBackColor = false;
            this.btnOptimalWorkingSheduler.Click += new System.EventHandler(this.btnOptimalWorkingSheduler_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 30;
            // 
            // state
            // 
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.Width = 60;
            // 
            // countTasksDone
            // 
            this.countTasksDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countTasksDone.HeaderText = "Count Tasks Done";
            this.countTasksDone.Name = "countTasksDone";
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.Width = 60;
            // 
            // speed
            // 
            this.speed.HeaderText = "Speed";
            this.speed.Name = "speed";
            this.speed.Width = 50;
            // 
            // countOperationsDone
            // 
            this.countOperationsDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countOperationsDone.HeaderText = "Count Operations Done";
            this.countOperationsDone.Name = "countOperationsDone";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 341);
            this.Controls.Add(this.btnOptimalWorkingSheduler);
            this.Controls.Add(this.btnWorkingSheduler);
            this.Controls.Add(this.btnSheduler);
            this.Controls.Add(this.totalOperationsDone);
            this.Controls.Add(this.totalTasksDone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.processorProbability);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxOperationsPerTask);
            this.Controls.Add(this.minOperationsPerTask);
            this.Controls.Add(this.taskProbability);
            this.Controls.Add(this.realEfficiency);
            this.Controls.Add(this.efficiency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBarTasksDone);
            this.Controls.Add(this.btnFIFO);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFIFO;
        public System.Windows.Forms.ProgressBar progressBarTasksDone;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox efficiency;
        private System.Windows.Forms.TextBox realEfficiency;
        private System.Windows.Forms.TextBox taskProbability;
        private System.Windows.Forms.TextBox minOperationsPerTask;
        private System.Windows.Forms.TextBox maxOperationsPerTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox processorProbability;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox totalTasksDone;
        private System.Windows.Forms.TextBox totalOperationsDone;
        private System.Windows.Forms.Button btnSheduler;
        private System.Windows.Forms.Button btnWorkingSheduler;
        private System.Windows.Forms.Button btnOptimalWorkingSheduler;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn countTasksDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn countOperationsDone;
    }
}

