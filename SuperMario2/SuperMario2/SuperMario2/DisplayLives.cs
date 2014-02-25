namespace SuperMario2
{
    using System;
    using System.Linq;

    public class DisplayLives : GameObject
    {
        public new const string CollisionGroupString = "displaylives";

        public DisplayLives(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { 'L', 'I', 'V', 'E', 'S', ':', '3' } })
        {
            this.Lives = 3;
        }

        public int Lives { get; set; }

        public override void Update()
        {
            // We have place only for one symbol
            if (this.Lives > 9)
            {
                this.Lives = 9;
            }

            char heroLives = char.Parse(this.Lives.ToString());

            char[,] heroLivesText = { { 'L', 'I', 'V', 'E', 'S', ':', '3' } };

            heroLivesText[0, 6] = heroLives;

            this.body = heroLivesText;
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
            return DisplayLives.CollisionGroupString;
        }
    }
}
