namespace SuperMario2
{
    using System;
    using System.Linq;

    public class Mario : GameObject
    {
        private new const string CollisionGroupString = "mario";
        protected int lives = 3;

        public Mario(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
            this.body = GetMyBody();
        }

        public int Lives
        {
            get
            {
                return this.lives;
            }

            private set
            {
                this.lives = value;
            }
        }

        public int MarioRow()
        {
            return this.TopLeft.Row;
        }

        public int MarioCol()
        {
            return this.TopLeft.Col;
        }

        public void MoveLeft()
        {
            this.topLeft.Col--;
        }

        public void MoveRight()
        {
            this.topLeft.Col++;
        }

        public void MoveUp()
        {
            this.topLeft.Row--;
        }

        public void MoveDown()
        {
            this.topLeft.Row++;
        }

        public override string GetCollisionGroupString()
        {
            return Mario.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "enemy" || otherCollisionGroupString == "brick";
        }

        public override void Update()
        {
            if (this.IsDestroyed)
            {
                this.body = new char[,] { { ' ' } };
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.Lives--;

            if (lives <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        /// <summary>
        /// Mario hero visualization
        /// </summary>
        private char[,] GetMyBody()
        {
            char[,] body = {
                                { ' ',' ',' ','\u2588','\u2588','\u2588',' ',' ',' ', },
                                { ' ',' ','\u2588','.','\u2588','.','\u2588',' ',' ', },
                                { ' ',' ',' ','\u2588','\u2588','\u2588',' ',' ',' ', },
                                { ' ',' ',' ',' ','\u2588',' ',' ',' ',' ', },
                                { '.','\u2588','\u2588','\u2588','\u2588','\u2588','\u2588','\u2588','.', },
                                { ' ',' ',' ','\u2588','M','\u2588',' ',' ',' ', },
                                { ' ',' ','\u2588','\u2588','\u2588','\u2588','\u2588',' ',' ', },
                                { ' ',' ','\u2588',' ','$',' ','\u2588',' ',' ', },
                                { ' ',' ','\u2588',' ',' ',' ','\u2588',' ',' ', },
                                { '.','\u2588','\u2588',' ',' ',' ','\u2588','\u2588','.', },
                           };
            return body;
        }
    }
}
