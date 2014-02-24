using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2
{
    class FlyingTurtle:Enemy, IEnemy
    {
        private MatrixCoords flyingTurtleSpeed = new MatrixCoords(-1,1);
        

        public FlyingTurtle(MatrixCoords topLeft)
            : base(topLeft){
        }

        public void FlyTurtleSpeed()
        {
            this.Speed = flyingTurtleSpeed;
        }

        protected new void UpdatePosition()
        {
            this.TopLeft += this.Speed;
            if (this.IsDestroyed)
            {
                this.body = new char[,] { { ' ' } };
            }
        }

        
        public override char[,] GetMyBody()
        {
            char[,] flyingTurtle = {
                               { '*', '\u2588', ' ','/', }, 
                               { ' ', '\u2588', '\u2588' ,'/', }, 
                               { ' ', '\u2588', '\u2588' ,'/',}, 
                               { ' ', '\u2588', ' ' ,'\u2588',}, 
                           };
            return flyingTurtle;
        }
    }
}
