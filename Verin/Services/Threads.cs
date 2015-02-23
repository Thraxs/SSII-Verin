using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Verin
{
    static class Threads
    {
        public static int parallelThreads;
        public static int activeThreads;
        public static List<HashTask> tasks;
        private static TaskManager taskManager;

        public static void init()
        {
            parallelThreads = 8;
            tasks = new List<HashTask>();
            activeThreads = 0;
        }

        //Add a new task to the queue and start the task manager if it isn't already started
        public static void addTask(File file, TaskType type)
        {
            //Create a new task and add it to the list
            HashTask task = new HashTask(file, type);
            tasks.Add(task);

            //If there are no active threads, create a task manager and start it
            if (activeThreads == 0)
            {
                taskManager = new TaskManager();
                Thread thread = new Thread(taskManager.start);
            }
        }

        //Execute the given task
        public static void runTask(HashTask task)
        {
            //Create a new thread and start the task
            Thread thread = new Thread(task.execute);
            thread.Start();
        }

        //End the given task
        public static void endTask(HashTask task)
        {
            //Decrease active thread count and remove finished task
            activeThreads--;
            tasks.Remove(task);
            task = null;

            //If there are no more tasks, delete the task manager
            if (activeThreads == 0)
            {
                taskManager = null;
            }
        }
    }
}
