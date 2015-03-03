using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
        public static TaskManager taskManager;
        public static Form1 form;

        public static void init(Form1 sender)
        {
            parallelThreads = 8;
            tasks = new List<HashTask>();
            activeThreads = 0;
            form = sender;
        }

        //Add a new task to the queue and start the task manager if it isn't already started
        public static void addTask(File file, TaskType type, bool backgroundTask)
        {
            //Create a new task and add it to the list
            HashTask task = new HashTask(file, type, backgroundTask);
            tasks.Add(task);

            //If there are no active threads, create a task manager and start it
            if (taskManager == null)
            {
                taskManager = new TaskManager();
                Thread thread = new Thread(taskManager.start);
                thread.Start();
            }
        }

        //Execute first task in the list
        public static void runTask()
        {
            if (tasks.Count == 0) return; //If there are no tasks, do nothing

            activeThreads++;

            //Get the first task from the list and remove it
            HashTask task = tasks[0];
            tasks.Remove(task);

            //Create a new thread and start the task
            Thread thread = new Thread(task.execute);
            thread.Start();
        }

        //End the given task
        public static void endTask(HashTask task)
        {
            if (!task.backgroundTask)
            {
                form.updateListViewItem(task.file);
            }

            //If the task is the last from a folder, register hash computation date and write folder log
            if (task.file.isLastFileToHash())
            {
                if (!task.file.folder.hashingFinished)
                {
                    task.file.folder.hashingFinished = true;
                    task.file.folder.lastHash = DateTime.Now;
                    Logger.writeFolderLog(task.file.folder);
                    if (!task.backgroundTask)
                    {
                        form.refreshFileList();
                    }
                }
            }

            //Decrease active thread count and delete finished task
            activeThreads--;
            task = null;

            //If there are no more tasks, delete the task manager
            if (activeThreads == 0)
            {
                taskManager = null;
            }
        }
    }
}
