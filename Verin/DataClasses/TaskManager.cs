using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    class TaskManager
    {
        public void start()
        {
            while (Threads.tasks.Count != 0)
            {
                if (Threads.activeThreads < Threads.parallelThreads)
                {
                    Threads.runTask();
                }
            }
        }
    }
}
