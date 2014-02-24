namespace SuperMario2
{
    using System;
    using System.Linq;

    public class Timer : GameObject
    {
        public new const string CollisionGroupString = "timer";

        private int timer;

        public Timer(MatrixCoords topLeft)
            : base(topLeft, new char[,] { 
                                            { 'P', 'O', 'I', 'N', 'T', 'S' }, 
                                            { '0', '0', '0', '0', '0', '0' },
                                        })
        {
            this.timer = 0;
        }

        public override void Update()
        {
            timer++;

            char[] p = timer.ToString().PadLeft(6, '0').ToCharArray();
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
