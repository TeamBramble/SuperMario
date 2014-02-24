namespace SuperMario2
{
    using System;
    using System.Linq;

    public class Enemy : MovingObject
    {
        private new const string CollisionGroupString = "enemy";

        public Enemy(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { ' ' } }, speed)
        {
            this.body = GetMyBody();
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "mario";
        }

        public override string GetCollisionGroupString()
        {
            return Enemy.CollisionGroupString;
        }

        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;

            if (this.IsDestroyed)
            {
                this.body = new char[,] { { ' ' } };
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        /// <summary>
        ///  Just an exampy to draw brick body
        /// </summary>
        /// <returns></returns>
        private char[,] GetMyBody()
        {
            char[,] body = {
                               { ' ', '*', ' ', }, 
                               { ' ', '\u2588', ' ', }, 
                               { '\u2588', ' ', '\u2588', }, 
                           };
            return body;
        }
    }
}
