using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace Millie_Quest_for_Dinner
{
    public static class Watch
    {
        private static Stopwatch _stopwatch = new Stopwatch();
        private static long _deltaTime; 

        public static long DeltaTime
        {
            get
            {
                return _deltaTime; 
            }
            set
            {
                _deltaTime = value;  
            }
        }

        public static void MeasureDeltaTime()
        {
            if (_stopwatch.IsRunning)
            {
                _deltaTime = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Stop();
                _stopwatch.Reset();

            } else
            {
                _stopwatch.Start();
            }
        }
    }
}

