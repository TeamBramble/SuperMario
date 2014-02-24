namespace SuperMario2
{
    using System;
    using System.Linq;

    public class MovingObject : GameObject
    {
        public MatrixCoords Speed { get; set; }

        public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
