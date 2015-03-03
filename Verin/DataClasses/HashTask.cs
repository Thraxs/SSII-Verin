using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Verin
{
    public enum TaskType { BASEHASH, LATESTHASH };

    class HashTask
    {
        public File file { get; set; }
        public TaskType type { get; set; }
        public bool backgroundTask { get; set; }

        public HashTask(File file, TaskType type, bool backgroundTask)
        {
            this.file = file;
            this.type = type;
            this.backgroundTask = backgroundTask;
        }

        public void execute()
        {
            if (type == TaskType.BASEHASH)
            {
                file.computeBaseHash();
            }
            else
            {
                file.computeLatestHash();
            }

            Threads.endTask(this);
        }
    }
}
