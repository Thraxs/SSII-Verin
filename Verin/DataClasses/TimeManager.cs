using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Verin
{
    //Checks periodically all folders to compute the hashes if its their time to do so
    class TimeManager
    {
        public void start()
        {
            while (!_stop)
            {
                foreach (Folder folder in Folders.get())
                {
                    if (folder.periodicity != Periodicity.NO)
                    {
                        folder.findNewFiles();

                        double difference = (DateTime.Now - folder.lastHash).TotalMinutes;

                        if (DateTime.Now > folder.lastHash)
                        {
                            //If enough time has passed, compute hash again
                            if (difference > folder.getPeriodicityInMinutes())
                            {
                                folder.computeHashes(true);
                            }
                        }
                    }
                }

                //Sleep for 1 minute before checking again
                Thread.Sleep(60000);
            }
        }

        public void stop()
        {
            _stop = true;
        }
        private volatile bool _stop;
    }
}
