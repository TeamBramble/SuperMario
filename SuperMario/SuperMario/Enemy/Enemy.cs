namespace SuperMario
{
    using System;

    public abstract class Enemy : IEnemy, IMovable
    {
        public int PointValue { get; set; }
        public int LocationX { get; set; }
        public int LocationY{get; set;}
        
        public Enemy(int pointValue, int posX, int posY)
        {
            this.PointValue = pointValue;

            this.LocationX = posX;
            this.LocationY = posY;
        }
        public virtual void Moving()
        {
       
            RenderEngine.RenderEnemy(this,100);
         
        }


        

       
    }
}
