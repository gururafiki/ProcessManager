using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessManager
{
    class Process
    {
        public int Id { get; set; }
        public int DataGridRowIndex { get; set; }
        public int Speed { get; set; }//operations per milisecond
        public Channel<ProcessorTask> ProcessorTasks = new Channel<ProcessorTask>();
        public bool IsReady = true;
        public bool IsEnquenedTaskDone = true;
        public int TasksDone = 0;
        public int OperationsDone = 0;
        public Form1 ProgramForm;
        public string mode = "queue";// if sheduler -> "shedule" = shedule queue, "queue" -> process queue
        public Dictionary<int, Process> Processes = new Dictionary<int, Process>() ;
        public Process(int _Id,int _Speed)
        {
            Id = _Id;
            DataGridRowIndex = _Id - 1;
            Speed = _Speed;
        }
        
        public void PushTask(ProcessorTask task)
        {
            ProcessorTasks.Enqueue(task);
        }
        public void PushTask()
        {
            if(TaskManager.ProgramTasks.Peek().AvailableProcessors.Contains(Id))
            {
                ProcessorTask task = TaskManager.ProgramTasks.Dequeue();
                ProcessTask(task);
            }
        }
        
        public void ProcessTask(ProcessorTask task)
        {
            ProgramForm.SetDataGridValue("state", DataGridRowIndex, "WORK");
            IsReady = false;
            task.ProcessTask(this);
            OperationsDone += task.CountOperationsDone;
            TasksDone++;
            ProgramForm.SetDataGridValue("countTasksDone", DataGridRowIndex, TasksDone.ToString());
            ProgramForm.SetDataGridValue("countOperationsDone", DataGridRowIndex, OperationsDone.ToString());
            IsReady = true;
            ProgramForm.SetDataGridValue("state", DataGridRowIndex, "WAIT");
        }
        public void ProcessTaskByParts(ProcessorTask task)
        {
            ProgramForm.SetDataGridValue("state", DataGridRowIndex, "WORK");
            IsReady = false;
            task.ProcessTaskByParts(this);
            OperationsDone += task.CountOperationsDone;
            if (task.IsCompleted)
            {
                TasksDone++;
                ProcessorTasks.Dequeue();
                ProgramForm.SetDataGridValue("countTasksDone", DataGridRowIndex, TasksDone.ToString());
                ProgramForm.SetDataGridValue("countOperationsDone", DataGridRowIndex, OperationsDone.ToString());
            }
            IsReady = true;
            ProgramForm.SetDataGridValue("state", DataGridRowIndex, "WAIT");
        }
        public void ProcessProgramQueue()//FIFO
        {
            //while(TaskManager.TotalTaskDone < TaskManager.TotalTaskDo)
            while(ProgramForm.Ticks < ProgramForm.TimeWorking)
            {
                if( TaskManager.ProgramTasks.Count != 0 
                    && TaskManager.ProgramTasks.Peek().AvailableProcessors.Contains(Id) 
                    && IsReady)
                {
                    PushTask();
                }
            }
        }

        public void ProcessQueue()
        {
            //while(TaskManager.TotalTaskDone < TaskManager.TotalTaskDo)
            while (ProgramForm.Ticks < ProgramForm.TimeWorking)
            {
                if (ProcessorTasks.Count != 0 && IsReady)
                {
                    ProcessTask(ProcessorTasks.Dequeue());
                }
            }
        }

        public void SheduleAndProcessQueue()
        {
            //while(TaskManager.TotalTaskDone < TaskManager.TotalTaskDo)
            while (ProgramForm.Ticks < ProgramForm.TimeWorking)
            {
                if(Form1.Mode == Form1.Modes.WithCustomWorkingSheduler)
                {
                    if (TaskManager.ProgramTasks.Count != 0)
                        mode = "shedule";
                    else
                        mode = "queue";
                }

                if (TaskManager.ProgramTasks.Count != 0 && mode == "shedule")
                {
                    ProcessorTask task = TaskManager.ProgramTasks.Dequeue();
                    KeyValuePair<int, int> unloadedProcess = new KeyValuePair<int, int>(0, 0);
                    foreach (var kvp in Processes)
                    {
                        if (task.AvailableProcessors.Contains(kvp.Key))
                        {
                            if (unloadedProcess.Key == 0 || unloadedProcess.Value > kvp.Value.ProcessorTasks.Count)
                            {
                                unloadedProcess = new KeyValuePair<int, int>(kvp.Key, kvp.Value.ProcessorTasks.Count);
                            }
                        }
                    }
                    Processes[unloadedProcess.Key].PushTask(task);
                }
                else if (ProcessorTasks.Count != 0 && IsReady && mode == "queue")
                {
                    ProcessTaskByParts(ProcessorTasks.Peek());
                }
            }
        }

        public void SheduleQueue()//Sheduler
        {
            
            while (ProgramForm.Ticks < ProgramForm.TimeWorking)
            {
                if ( TaskManager.ProgramTasks.Count != 0 )
                {
                    ProcessorTask task = TaskManager.ProgramTasks.Dequeue();
                    KeyValuePair<int,int> unloadedProcess = new KeyValuePair<int, int>( 0, 0);
                    foreach (var kvp in Processes)
                    {
                        if (task.AvailableProcessors.Contains(kvp.Key))
                        {
                            if(unloadedProcess.Key == 0 || unloadedProcess.Value > kvp.Value.ProcessorTasks.Count)
                            {
                                unloadedProcess = new KeyValuePair<int, int>(kvp.Key, kvp.Value.ProcessorTasks.Count);
                            }
                        }
                    }
                    Processes[unloadedProcess.Key].PushTask(task);
                }
            }
        }
    }
    
}
