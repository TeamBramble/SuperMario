using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class BonusLives : Bonus
    {
        private new const string CollisionGroupString = "bonuslives";

        public BonusLives(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = GetMyBody();
        }

        public override char[,] GetMyBody()
        {
            char[,] turtleBody = { { '+', '1', ' ', 'L', 'I', 'V', 'E' } };

            return turtleBody;
        }

        public override string GetCollisionGroupString()
        {
            return BonusLives.CollisionGroupString;
        }
    }
}
