using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessManager
{
    class TaskManager
    {
        public int ProbabilityEmergenceTask { get; set; }
        public static int ProbabilityEmergenceProcessor { get; set; }
        public static Channel<ProcessorTask> ProgramTasks = new Channel<ProcessorTask>();
        public static int TotalTaskDo = 1000;
        public static int TotalTaskDone = 0;
        public static int TotalOperationsDone = 0;
        public int MinOperationsPerTask = 0;
        public int MaxOperationsPerTask = 0;
        public static Random gen = new Random();
        public Form1 ProgramForm;
        public TaskManager()
        {
        }
        public void StartCreatingTasks()
        {
            while(ProgramForm.Ticks < ProgramForm.TimeWorking)
            {
                if (CanAddTask)
                    CreateTask(new ProcessorTask(GetRandomedTaskOperations()));

                Thread.Sleep(1);
                //ProgramForm.SetProgressBarValue(TotalTaskDone);
            }
        }
        public int GetRandomedTaskOperations()
        {
            //if the slowest processor has speed 100 then the longest task will take beetween 20ms and 190ms
            return gen.Next(MinOperationsPerTask, MaxOperationsPerTask);
        }
        public bool CanAddTask {
            get
            {
                int result = gen.Next(10000);
                return result <= ProbabilityEmergenceTask;
            }
        }

        public void CreateTask(ProcessorTask task)
        {
            ProgramTasks.Enqueue(task);
        }
    }
    class ProcessorTask //: Task
    {
        public List<int> AvailableProcessors = GetRandomedProcessors();
        public int CountOperations { get; set; }
        public int CountOperationsDone = 0;
        public bool IsCompleted = false;
        public bool IsWorking = false;
        public ProcessorTask(int _CountOperations) //: base(action)
        {
            CountOperations = _CountOperations;
        }
        private static List<int> GetRandomedProcessors()
        {
            List<int> randomedProcessors = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                if (ThreadManager.ShedulerId == i && Form1.Mode == Form1.Modes.WithSheduler)
                    continue;

                int result = TaskManager.gen.Next(10000);
                if (result <= TaskManager.ProbabilityEmergenceProcessor)
                {
                    randomedProcessors.Add(i);
                }
            }

            while ( randomedProcessors.Count == 0 )
            {
                int processorId = TaskManager.gen.Next(1, 5);

                if (ThreadManager.ShedulerId == processorId && Form1.Mode == Form1.Modes.WithSheduler)
                    continue;

                randomedProcessors.Add(processorId);
            }

            return randomedProcessors;
        }
        public void ProcessTask(Process process)
        {
            IsWorking = true;
            
            int delay = CountOperations / process.Speed;
            Thread.Sleep(delay);
            CountOperationsDone = delay * process.Speed;
            TaskManager.TotalOperationsDone += CountOperationsDone;
            TaskManager.TotalTaskDone++;
            IsWorking = false;
            IsCompleted = true;
        }
        public void ProcessTaskByParts(Process process)
        {
            IsWorking = true;
            
            while(CountOperationsDone < CountOperations && process.mode == "queue")
            {
                Thread.Sleep(1);
                CountOperationsDone += process.Speed;
            }
            TaskManager.TotalOperationsDone += CountOperationsDone;

            if(CountOperationsDone >= CountOperations)
            {
                TaskManager.TotalTaskDone++;
                IsCompleted = true;
            }

            IsWorking = false;
        }
    }
    public class Channel<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public void Enqueue(T item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item);
                if (_queue.Count == 1)
                    Monitor.PulseAll(_queue);
            }
        }

        public T Dequeue()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                    Monitor.Wait(_queue);

                return _queue.Dequeue();
            }
        }

        public T Peek()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                    Monitor.Wait(_queue);

                return _queue.Peek();
            }
        }

        public int Count
        {
            get
            {
                lock (_queue)
                {
                    return _queue.Count;
                }
            }
        }
    }
}
