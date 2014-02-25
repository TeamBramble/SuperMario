namespace SuperMario2
{
    using System;
    using System.Linq;

    public abstract class Bonus : MovingObject
    {
        private new const string CollisionGroupString = "bonus";

        public Bonus(MatrixCoords topLeft, MatrixCoords speed)
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
            return Bonus.CollisionGroupString;
        }

        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;

            if (this.IsDestroyed)
            {
                this.topLeft = new MatrixCoords(-1, -1);
                this.body = new char[,] { { ' ' } };
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public virtual char[,] GetMyBody()
        {
            char[,] body = { { ' ' } };
            return body;
        }
    }
}
