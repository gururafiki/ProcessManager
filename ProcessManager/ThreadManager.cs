using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessManager
{
    class ThreadManager
    {
        public Dictionary<int, int> ProcessorsSpeed = new Dictionary<int, int>();
        public static Dictionary<int, Process> Processes = new Dictionary<int, Process>();
        public int TaskProbability;
        public int ProcessorProbability;
        public int MinOperationsPerTask;
        public int MaxOperationsPerTask;
        public static int ShedulerId = 0;
        Thread TaskCreator;
        Thread Thread1;
        Thread Thread2;
        Thread Thread3;
        Thread Thread4;
        Thread Thread5;
        public static Form1 ProgramForm;
        private static Timer timer;
        private static int ticks = 0;
        public static int TotalTicks = 0;
        public static int TickInterval = 4;
        public static int TicksForQueue = 5;
        public static int TicksForShedule = 1;

        private static void CountOnCallBack()
        {
            if (Processes[ShedulerId].mode == "shedule")
            {
                TicksForShedule++;
            }
            else if (Processes[ShedulerId].mode == "queue")
            {
                TicksForQueue++;
            }
            if (ProgramForm.Ticks < ProgramForm.TimeWorking)
                timer = new Timer(_ => CountOnCallBack(), null, dueTime: TickInterval, period: Timeout.Infinite);
        }

        private static void OnCallBack()
        {
            TotalTicks++;
            ticks++;
            if(ticks % TicksForQueue == 0 && Processes[ShedulerId].mode == "shedule")
            {
                Processes[ShedulerId].mode = "queue";
                ticks = 0;
            }
            else if(ticks % TicksForShedule == 0 && Processes[ShedulerId].mode == "queue")
            {
                Processes[ShedulerId].mode = "shedule";
                ticks = 0;
            }
            if(ProgramForm.Ticks < ProgramForm.TimeWorking)
                timer = new Timer(_ => OnCallBack(), null, dueTime: TickInterval, period: Timeout.Infinite);
        }
        public ThreadManager()
        {

        }
        public void DisableAllThreads()
        {
            try
            {
                while (TaskManager.ProgramTasks.Count > 0)
                    TaskManager.ProgramTasks.Dequeue();

                TaskCreator.Abort();
                Thread1.Abort();
                Thread2.Abort();
                Thread3.Abort();
                Thread4.Abort();
                Thread5.Abort();
                Processes.Clear();
                timer.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        public void Work()
        {
            Process Process1 = new Process(1, ProcessorsSpeed[1]);
            Process1.ProgramForm = ProgramForm;
            Process Process2 = new Process(2, ProcessorsSpeed[2]);
            Process2.ProgramForm = ProgramForm;
            Process2.TasksDone = 0;
            Process Process3 = new Process(3, ProcessorsSpeed[3]);
            Process3.ProgramForm = ProgramForm;
            Process Process4 = new Process(4, ProcessorsSpeed[4]);
            Process4.ProgramForm = ProgramForm;
            Process Process5 = new Process(5, ProcessorsSpeed[5]);
            Process5.ProgramForm = ProgramForm;

            Processes.Add(Process1.Id,Process1);
            Processes.Add(Process2.Id,Process2);
            Processes.Add(Process3.Id,Process3);
            Processes.Add(Process4.Id,Process4);
            Processes.Add(Process5.Id,Process5);
            
            TaskManager.ProbabilityEmergenceProcessor = ProcessorProbability;
            TaskManager.TotalOperationsDone = 0;
            TaskManager.TotalTaskDone = 0;

            TaskManager taskManager = new TaskManager();
            taskManager.ProgramForm = ProgramForm;
            taskManager.ProbabilityEmergenceTask = TaskProbability;
            taskManager.MinOperationsPerTask = MinOperationsPerTask;
            taskManager.MaxOperationsPerTask = MaxOperationsPerTask;

            TaskCreator = new Thread(new ThreadStart(taskManager.StartCreatingTasks));
            switch (Form1.Mode)
            {
                case Form1.Modes.WithSheduler:
                    if (ShedulerId == 1)
                    {
                        //Process1.Processes.Add(1, Process1);
                        Process1.Processes.Add(2, Process2);
                        Process1.Processes.Add(3, Process3);
                        Process1.Processes.Add(4, Process4);
                        Process1.Processes.Add(5, Process5);
                        Thread1 = new Thread(new ThreadStart(Process1.SheduleQueue));
                    }
                    else
                        Thread1 = new Thread(new ThreadStart(Process1.ProcessQueue));

                    if (ShedulerId == 2)
                    {
                        Process2.Processes.Add(1, Process1);
                        //Process2.Processes.Add(2, Process2);
                        Process2.Processes.Add(3, Process3);
                        Process2.Processes.Add(4, Process4);
                        Process2.Processes.Add(5, Process5);
                        Thread2 = new Thread(new ThreadStart(Process2.SheduleQueue));
                    }
                    else
                        Thread2 = new Thread(new ThreadStart(Process2.ProcessQueue));

                    if (ShedulerId == 3)
                    {

                        Process3.Processes.Add(1, Process1);
                        Process3.Processes.Add(2, Process2);
                        //Process3.Processes.Add(3, Process3);
                        Process3.Processes.Add(4, Process4);
                        Process3.Processes.Add(5, Process5);
                        Thread3 = new Thread(new ThreadStart(Process3.SheduleQueue));
                    }
                    else
                        Thread3 = new Thread(new ThreadStart(Process3.ProcessQueue));

                    if (ShedulerId == 4)
                    {
                        Process4.Processes.Add(1, Process1);
                        Process4.Processes.Add(2, Process2);
                        Process4.Processes.Add(3, Process3);
                        //Process4.Processes.Add(4, Process4);
                        Process4.Processes.Add(5, Process5);
                        Thread4 = new Thread(new ThreadStart(Process4.SheduleQueue));
                    }
                    else
                        Thread4 = new Thread(new ThreadStart(Process4.ProcessQueue));

                    if (ShedulerId == 5)
                    {

                        Process5.Processes.Add(1, Process1);
                        Process5.Processes.Add(2, Process2);
                        Process5.Processes.Add(3, Process3);
                        Process5.Processes.Add(4, Process4);
                        //Process5.Processes.Add(5, Process5);
                        Thread5 = new Thread(new ThreadStart(Process5.SheduleQueue));
                    }
                    else
                        Thread5 = new Thread(new ThreadStart(Process5.ProcessQueue));
                    break;
                case Form1.Modes.Fifo:
                    Thread1 = new Thread(new ThreadStart(Process1.ProcessProgramQueue));
                    Thread2 = new Thread(new ThreadStart(Process2.ProcessProgramQueue));
                    Thread3 = new Thread(new ThreadStart(Process3.ProcessProgramQueue));
                    Thread4 = new Thread(new ThreadStart(Process4.ProcessProgramQueue));
                    Thread5 = new Thread(new ThreadStart(Process5.ProcessProgramQueue));
                    break;
                default:
                    if (ShedulerId == 1)
                    {
                        Process1.Processes.Add(1, Process1);
                        Process1.Processes.Add(2, Process2);
                        Process1.Processes.Add(3, Process3);
                        Process1.Processes.Add(4, Process4);
                        Process1.Processes.Add(5, Process5);
                        Thread1 = new Thread(new ThreadStart(Process1.SheduleAndProcessQueue));
                    }
                    else
                        Thread1 = new Thread(new ThreadStart(Process1.ProcessQueue));

                    if (ShedulerId == 2)
                    {
                        Process2.Processes.Add(1, Process1);
                        Process2.Processes.Add(2, Process2);
                        Process2.Processes.Add(3, Process3);
                        Process2.Processes.Add(4, Process4);
                        Process2.Processes.Add(5, Process5);
                        Thread2 = new Thread(new ThreadStart(Process2.SheduleAndProcessQueue));
                    }
                    else
                        Thread2 = new Thread(new ThreadStart(Process2.ProcessQueue));

                    if (ShedulerId == 3)
                    {

                        Process3.Processes.Add(1, Process1);
                        Process3.Processes.Add(2, Process2);
                        Process3.Processes.Add(3, Process3);
                        Process3.Processes.Add(4, Process4);
                        Process3.Processes.Add(5, Process5);
                        Thread3 = new Thread(new ThreadStart(Process3.SheduleAndProcessQueue));
                    }
                    else
                        Thread3 = new Thread(new ThreadStart(Process3.ProcessQueue));

                    if (ShedulerId == 4)
                    {
                        Process4.Processes.Add(1, Process1);
                        Process4.Processes.Add(2, Process2);
                        Process4.Processes.Add(3, Process3);
                        Process4.Processes.Add(4, Process4);
                        Process4.Processes.Add(5, Process5);
                        Thread4 = new Thread(new ThreadStart(Process4.SheduleAndProcessQueue));
                    }
                    else
                        Thread4 = new Thread(new ThreadStart(Process4.ProcessQueue));

                    if (ShedulerId == 5)
                    {

                        Process5.Processes.Add(1, Process1);
                        Process5.Processes.Add(2, Process2);
                        Process5.Processes.Add(3, Process3);
                        Process5.Processes.Add(4, Process4);
                        Process5.Processes.Add(5, Process5);
                        Thread5 = new Thread(new ThreadStart(Process5.SheduleAndProcessQueue));
                    }
                    else
                        Thread5 = new Thread(new ThreadStart(Process5.ProcessQueue));
                    break;
            }
            
            TaskCreator.Start();
            Thread1.Start();
            Thread2.Start();
            Thread3.Start();
            Thread4.Start();
            Thread5.Start();
            
            if(Form1.Mode == Form1.Modes.WithWorkingSheduler)
            {
                TicksForQueue = 5;
                TicksForShedule = 1;
                TickInterval = 4;
                timer = new Timer(_ => OnCallBack(), null, dueTime: TickInterval, period: Timeout.Infinite);
            }

            if(Form1.Mode == Form1.Modes.WithCustomWorkingSheduler)
            {
                TicksForQueue = 0;
                TicksForShedule = 0;
                TickInterval = 1;
                timer = new Timer(_ => CountOnCallBack(), null, dueTime: TickInterval, period: Timeout.Infinite);
            }

        }
    }
}
