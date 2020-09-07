using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProcessManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("1","WAIT","0","Worker",184,0);
            dataGridView1.Rows.Add("2", "WAIT", "0", "Worker", 235, 0);
            dataGridView1.Rows.Add("3", "WAIT", "0", "Worker", 112, 0);
            dataGridView1.Rows.Add("4", "WAIT", "0", "Worker", 83, 0);
            dataGridView1.Rows.Add("5", "WAIT", "0", "Worker", 691, 0);
        }
        public int Ticks = 0;
        public int TimeWorking = 10;
        private ThreadManager threadManager = new ThreadManager();
        public enum Modes
        {
            Fifo,
            WithSheduler,
            WithWorkingSheduler,
            WithCustomWorkingSheduler
        }
        public static Modes Mode;

        private void btnSheduler_Click(object sender, EventArgs e)
        {
            Ticks = 0;
            Mode = Modes.WithSheduler;

            Dictionary<int, int> processorsSpeed = new Dictionary<int, int>();
            ThreadManager.ShedulerId = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1[3, i].Value.ToString() == "Sheduler")
                    ThreadManager.ShedulerId = i + 1;
                processorsSpeed.Add(Convert.ToInt32(dataGridView1[0, i].Value), Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value));
            }
            if(ThreadManager.ShedulerId == 0)
            {
                ThreadManager.ShedulerId = processorsSpeed.OrderBy(kvp => kvp.Value).FirstOrDefault().Key;
            }

            SetDataGridValue("type",(ThreadManager.ShedulerId - 1),"Sheduler");
            
            threadManager.ProcessorsSpeed = processorsSpeed;
            threadManager.TaskProbability = (int)(Convert.ToDouble(taskProbability.Text) * 100);
            threadManager.ProcessorProbability = (int)(Convert.ToDouble(processorProbability.Text) * 100);
            threadManager.MinOperationsPerTask = Convert.ToInt32(minOperationsPerTask.Text);
            threadManager.MaxOperationsPerTask = Convert.ToInt32(maxOperationsPerTask.Text);
            timer.Enabled = true;
            ThreadManager.ProgramForm = this;
            Thread programThread = new Thread(new ThreadStart(threadManager.Work));
            programThread.Start();
        }

        private void btnOptimalWorkingSheduler_Click(object sender, EventArgs e)
        {
            Ticks = 0;
            Mode = Modes.WithCustomWorkingSheduler;

            Dictionary<int, int> processorsSpeed = new Dictionary<int, int>();
            ThreadManager.ShedulerId = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1[3, i].Value.ToString() == "Sheduler")
                    ThreadManager.ShedulerId = i + 1;

                processorsSpeed.Add(Convert.ToInt32(dataGridView1[0, i].Value), Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value));
            }

            if (ThreadManager.ShedulerId == 0)
            {
                ThreadManager.ShedulerId = processorsSpeed.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;
            }

            SetDataGridValue("type", (ThreadManager.ShedulerId - 1), "Sheduler");

            threadManager.ProcessorsSpeed = processorsSpeed;
            threadManager.TaskProbability = (int)(Convert.ToDouble(taskProbability.Text) * 100);
            threadManager.ProcessorProbability = (int)(Convert.ToDouble(processorProbability.Text) * 100);
            threadManager.MinOperationsPerTask = Convert.ToInt32(minOperationsPerTask.Text);
            threadManager.MaxOperationsPerTask = Convert.ToInt32(maxOperationsPerTask.Text);
            timer.Enabled = true;
            ThreadManager.ProgramForm = this;
            Thread programThread = new Thread(new ThreadStart(threadManager.Work));
            programThread.Start();

        }

        private void btnWorkingSheduler_Click(object sender, EventArgs e)
        {
            Ticks = 0;
            Mode = Modes.WithWorkingSheduler;

            Dictionary<int, int> processorsSpeed = new Dictionary<int, int>();
            ThreadManager.ShedulerId = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1[3, i].Value.ToString() == "Sheduler")
                    ThreadManager.ShedulerId = i + 1;

                processorsSpeed.Add(Convert.ToInt32(dataGridView1[0, i].Value), Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value));
            }

            if (ThreadManager.ShedulerId == 0)
            {
                ThreadManager.ShedulerId = processorsSpeed.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;
            }

            SetDataGridValue("type", (ThreadManager.ShedulerId - 1), "Sheduler");

            threadManager.ProcessorsSpeed = processorsSpeed;
            threadManager.TaskProbability = (int)(Convert.ToDouble(taskProbability.Text) * 100);
            threadManager.ProcessorProbability = (int)(Convert.ToDouble(processorProbability.Text) * 100);
            threadManager.MinOperationsPerTask = Convert.ToInt32(minOperationsPerTask.Text);
            threadManager.MaxOperationsPerTask = Convert.ToInt32(maxOperationsPerTask.Text);
            timer.Enabled = true;
            ThreadManager.ProgramForm = this;
            Thread programThread = new Thread(new ThreadStart(threadManager.Work));
            programThread.Start();

        }
        private void btnFIFO_Click(object sender, EventArgs e)
        {
            /*
            if (!backgroundWorker1.IsBusy)
            {
                _inputparameter.Delay = 100;
                _inputparameter.Process = 1200;
                backgroundWorker1.RunWorkerAsync(_inputparameter);
            }
            */
            Ticks = 0;
            Mode = Modes.Fifo;

            Dictionary<int, int> processorsSpeed = new Dictionary<int, int>();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                processorsSpeed.Add(Convert.ToInt32(dataGridView1[0, i].Value),Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value));
            }
            threadManager.ProcessorsSpeed = processorsSpeed;
            threadManager.TaskProbability = (int)(Convert.ToDouble(taskProbability.Text)*100);
            threadManager.ProcessorProbability = (int)(Convert.ToDouble(processorProbability.Text)*100);
            threadManager.MinOperationsPerTask = Convert.ToInt32(minOperationsPerTask.Text);
            threadManager.MaxOperationsPerTask = Convert.ToInt32(maxOperationsPerTask.Text);
            timer.Enabled = true;
            ThreadManager.ProgramForm = this;
            Thread programThread = new Thread(new ThreadStart(threadManager.Work));
            programThread.Start();
        }
        /*
        private void stopBackgroundWorker1()
        {
            
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
        */
        delegate void SetProgressBarValueCallback(int value);

        public void SetProgressBarValue(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.progressBarTasksDone.InvokeRequired)
            {
                SetProgressBarValueCallback d = new SetProgressBarValueCallback(SetProgressBarValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBarTasksDone.Value = value;
            }
        }

        delegate void SetDataGridValueCallback(string col, int row, string value);

        public void SetDataGridValue(string col, int row, string value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dataGridView1.InvokeRequired)
            {
                SetDataGridValueCallback d = new SetDataGridValueCallback(SetDataGridValue);
                this.Invoke(d, new object[] { col, row, value });
            }
            else
            {
                this.dataGridView1[col,row].Value = value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Ticks++;
            if (Ticks == TimeWorking)
            {
                timer.Enabled = false;
                threadManager.DisableAllThreads();
                int totalSpeed = 0;
                int usedSpeed = 0;
                switch (Mode)
                {
                    case Modes.Fifo:
                        for (int i = 0;i < dataGridView1.Rows.Count; ++i)
                        {
                            totalSpeed += TimeWorking * timer.Interval * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                        }
                        efficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)totalSpeed) * 100).ToString("#.00");
                        realEfficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)totalSpeed) * 100).ToString("#.00");
                        totalTasksDone.Text = TaskManager.TotalTaskDone.ToString();
                        totalOperationsDone.Text = TaskManager.TotalOperationsDone.ToString();
                        break;
                    case Modes.WithSheduler:
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            if(Convert.ToInt32(dataGridView1[0, i].Value) != ThreadManager.ShedulerId)
                                usedSpeed += TimeWorking * timer.Interval * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                            totalSpeed += TimeWorking * timer.Interval * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                        }
                        efficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)usedSpeed) * 100).ToString("#.00");
                        realEfficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)totalSpeed) * 100).ToString("#.00");
                        totalTasksDone.Text = TaskManager.TotalTaskDone.ToString();
                        totalOperationsDone.Text = TaskManager.TotalOperationsDone.ToString();
                        break;
                    default:
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            if (Convert.ToInt32(dataGridView1[0, i].Value) == ThreadManager.ShedulerId)
                                usedSpeed += Convert.ToInt32( ((double)ThreadManager.TicksForQueue / ((double)ThreadManager.TicksForQueue + (double)ThreadManager.TicksForShedule)) * (double)TimeWorking * (double)timer.Interval ) * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                            else
                                usedSpeed += TimeWorking * timer.Interval * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                            totalSpeed += TimeWorking * timer.Interval * Convert.ToInt32(dataGridView1[(dataGridView1.Columns.Count - 2), i].Value);
                        }
                        efficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)usedSpeed) * 100).ToString("#.00");
                        realEfficiency.Text = (((double)TaskManager.TotalOperationsDone / (double)totalSpeed) * 100).ToString("#.00");
                        totalTasksDone.Text = TaskManager.TotalTaskDone.ToString();
                        totalOperationsDone.Text = TaskManager.TotalOperationsDone.ToString();
                        break;
                }
            }
            else
            {
                SetProgressBarValue(Ticks);
            }
        }


        /*
private void timer1_Tick(object sender, EventArgs e)
{
ticks++;
if(ticks == 1000)
{
timer1.Enabled = false;
}
else
{
SetProgressBarValue(ticks);
}
}
struct DataParameter
{
public int Process;
public int Delay;
}
private DataParameter _inputparameter;

private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
{
int process = ((DataParameter)e.Argument).Process;
int delay = ((DataParameter)e.Argument).Delay;
int index = 1;
try
{
for(int i = 0; i< process; i++)
{
  if (!backgroundWorker1.CancellationPending)
  {
      backgroundWorker.ReportProgress
  }
}
}
catch(Exception ex)
{
backgroundWorker1.CancelAsync();
MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
{
progress.Value = e.ProgressPercentage;
SetProgressBarValue(e.ProgressPercentage);
progress.Update();
}

private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
MessageBox.Show("Successfully Done");
}
*/
    }
}
