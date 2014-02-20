namespace SuperMario
{
    using System;

    public class Score
    {
        private const int INCREMENT_VALUE = 10;

        private double currentScore;
        private double finalscore;


        public Score()
        {
            currentScore = 0;
        }

        public double CurrentScore
        {
            get 
            { 
                return currentScore;
            }
            set
            {
                currentScore = value;
            }
        }

        public double Finalscore
        {
            get 
            { 
                return finalscore;
            }
            set
            {
                finalscore = value;
            }
        }

        public double get()
        {
            return currentScore;
        }

        //adds 10 points to the current score (on a new correctly guessed word position)
        public void increment()
        {
            currentScore += INCREMENT_VALUE;
            finalscore += INCREMENT_VALUE;
        }

        //penalty - lose half of the points (when you hit a brick?)
        public void decrement()
        {
            if (currentScore > 0)
            {
                currentScore /= 2;
                Finalscore /= 2;
            }
        }

        public void print()
        {
            //Console.SetCursorPosition();
            Console.CursorVisible = false;
            Console.WriteLine("Score: {0,-10}", currentScore);
            //Console.SetCursorPosition();
            Console.WriteLine("Total: {0,-10}", Finalscore);
        }
    }
}
