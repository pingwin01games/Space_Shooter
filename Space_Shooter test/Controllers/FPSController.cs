using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Space_Shooter
{
    //kontroler ktory nie jest odpowiedno zsynchronizowany z
    //innymi kontrolerami mierzacymi czas
    public class FPSController
    {
        private Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        private long msSincePreviousFrame;
        private long requiredTime;
        

        public FPSController(int FPS)
        {
            requiredTime = 1000 / FPS;
        }

        public void update()
        {
            stopwatch.Stop();
            msSincePreviousFrame = stopwatch.ElapsedMilliseconds;
            long howMuchToSlow = requiredTime - msSincePreviousFrame;
            if(howMuchToSlow > 0)
            {
                Thread.Sleep((int)howMuchToSlow);
            }
            stopwatch.Restart();
        }
    }
}
