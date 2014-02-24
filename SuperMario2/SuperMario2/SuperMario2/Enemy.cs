namespace SuperMario2
{
    using System;
    using System.Linq;

    public abstract class Enemy : MovingObject,IEnemy

    {
        private new const string CollisionGroupString = "enemy";

        public Enemy(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
            this.body = GetMyBody();
        }

        public override void UpdatePosition()
        {
         
            this.TopLeft += this.Speed;
            if (this.IsDestroyed)
            {
                this.body = new char[,] { { ' ' } };
            }
        
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
            int rowSpeed = this.Speed.Row;
            int colSpeed = this.Speed.Col;
            if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
            {
                rowSpeed *= -1;
            }
            if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
            {
                colSpeed *= -1;
            }
            MatrixCoords.Set(Speed, rowSpeed, colSpeed);
        }

        /// <summary>
        ///  Just an exampy to draw brick body
        /// </summary>
        /// <returns></returns>
        public virtual char[,] GetMyBody()
        {
            char[,] body = {
                               { ' ', '*', ' ', ' ',}, 
                               { ' ', '\u2588', ' ',' ', }, 
                               { '\u2588', ' ', '\u2588',' ', },
                               { '\u2588', ' ', '\u2588',' ', }, 
                           };
            return body;
        }
    }
}
