namespace SuperMario2
{
    using System;
    using System.Linq;

    public abstract class MovingObject : GameObject
    {
        public MatrixCoords Speed { get; set; }

        public MovingObject(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
          
        }

        public virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
