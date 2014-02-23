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
            return otherCollisionGroupString == Brick.CollisionGroupString || otherCollisionGroupString == Mario.CollisionGroupString;
        }

        public override string GetCollisionGroupString()
        {
            return Enemy.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            // TODO: Here we have some error need to be fixed
            //if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
            //{
            //    this.Speed.Row *= -1;
            //}
            //if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
            //{
            //    this.Speed.Col *= -1;
            //}
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
