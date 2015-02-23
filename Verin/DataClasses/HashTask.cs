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
        public string result { get; set; }

        public HashTask(File file, TaskType type)
        {
            this.file = file;
            this.type = type;
        }

        public void execute()
        {
            if (type == TaskType.BASEHASH)
            {
                file.computeBaseHash();
                result = file.baseHash;
            }
            else
            {
                file.computeLatestHash();
                result = file.latestHash;
            }

            Threads.endTask(this);
        }
    }
}
