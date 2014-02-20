namespace SuperMario
{
    using System;

    public class Timer
    {
        private const int DEFAULT_GAME_TIME = 90; // in seconds 
   
        private int timeInterval;
        private int startTime;
        private int currentTime;
        private int endTime;
        private int timeLeft;

        public Timer()
        {
            initTimer(DEFAULT_GAME_TIME);
        }

        public Timer(int time) // Timer t = new Timer(40, 60, 8) - if we want to reduce the time for next levels;
        {
            initTimer(time);
        }

        private void initTimer(int time)
        {
            timeInterval = time;

            startTime = getCurrentTime();
            currentTime = startTime;
            endTime = startTime + time;
            //Console.WriteLine("Start time is: " + startTime);
            //Console.WriteLine(endTime);
        }

        private int getCurrentTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        private bool checkTick()
        {
            if (getCurrentTime() > currentTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateTimer()
        {
            if (checkTick())
            {
                currentTime += 1; // increment with 1 second
                timeLeft = timeInterval - (currentTime - startTime);

                if (timeLeft >= 0)
                {
                    //Console.SetCursorPosition();
                    Console.CursorVisible = false;
                    Console.WriteLine("Time: {0,-5}", timeLeft);
                    if (timeLeft > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false; // NOTE: We return false only if time is over!
                }
            }
            else
            {
                return true;
            }
        }
    }
}
