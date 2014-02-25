namespace SuperMario2
{
    using System;
    using System.Linq;

    public class BonusPoints : Bonus
    {
        private new const string CollisionGroupString = "bonuspoints";

        public BonusPoints(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = GetMyBody();
        }

        public override char[,] GetMyBody()
        {
            char[,] turtleBody = { { '-', '5', '0', ' ', 'P', 'O', 'I', 'N', 'T', 'S' } };
            
            return turtleBody;
        }

        public override string GetCollisionGroupString()
        {
            return BonusPoints.CollisionGroupString;
        }
    }
}