namespace SuperMario2
{
    using System;
    using System.Linq;

    public class Timer : GameObject
    {
        public new const string CollisionGroupString = "timer";

        public Timer(MatrixCoords topLeft)
            : base(topLeft, new char[,] { 
                                            { 'P', 'O', 'I', 'N', 'T', 'S' }, 
                                            { '0', '0', '0', '0', '0', '0' },
                                        })
        {
        }

        public int TimerClock { get; set; }

        public int OutTimer { get; set; }

        public override void Update()
        {
            this.TimerClock++;

            this.TimerClock -= this.OutTimer;

            if (this.TimerClock > 300)
            {
                this.IsDestroyed = true;
            }

            char[] p = TimerClock.ToString().PadLeft(6, '0').ToCharArray();
            char[,] p2d = { 
                            { 'P', 'O', 'I', 'N', 'T', 'S' }, 
                            { '0', '0', '0', '0', '0', '0' },
                          };

            for (int r = 1; r < 2; r++)
            {
                for (int c = 0; c < 6; c++)
                {
                    p2d[r, c] = p[c];
                }
            }

            this.body = p2d;
        }


        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return false;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
        }

        public override string GetCollisionGroupString()
        {
            return Timer.CollisionGroupString;
        }
    }
}
