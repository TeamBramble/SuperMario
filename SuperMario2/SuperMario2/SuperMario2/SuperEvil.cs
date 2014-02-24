using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2
{
    public class SuperEvil :Enemy
    {
        private bool hasMovedUp=false;
        
        public SuperEvil(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed) { }

        //TO DO да се override-не долният метод, така че да не фрийзва това Enemy
        protected override void UpdatePosition()
        {
            if (hasMovedUp)
            {
                this.TopLeft += this.Speed;

                if (this.IsDestroyed)
                {
                    this.topLeft = new MatrixCoords(-1, -1);
                    this.body = new char[,] { { ' ' } };
                }
                hasMovedUp = false;
            }
            if (!hasMovedUp)
            {
                this.TopLeft -= this.Speed;

                if (this.IsDestroyed)
                {
                    this.topLeft = new MatrixCoords(-1, -1);
                    this.body = new char[,] { { ' ' } };
                }
                hasMovedUp = true;
            }
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
        public override char[,] GetMyBody()
        {
            char[,] superEvilBody = {
                                { ' ', ' ','\u2588', '\u2588','\u2588','\u2588', }, 
                                { '<', '<','\u2588', '\u2588','.','\u2588', }, 
                                { ' ', ' ',' ', '*','\u2588', '\u2588',}, 
                                { ' ', ' ',' ', '*','\u2588', ' ',}, 
                                { '<', '\u2588','\u2588','\u2588','\u2588','\u2588', }, 
                                { '<', '\u2588','\u2588','\u2588','\u2588','\u2588', }, 
                                { '<', '\u2588','\u2588','\u2588','\u2588','\u2588', }, 
                                {  '<','\u2588', '\u2588','\u2588','\u2588','\u2588', }, 
                                {  '<','\u2588', ' ','\u2588', '\u2588','\u2588',}, 
                           };
            return superEvilBody;
        }
    }
}
