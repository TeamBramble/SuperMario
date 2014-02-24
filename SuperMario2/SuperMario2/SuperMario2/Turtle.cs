using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class Turtle:Enemy,IEnemy
    {
        MatrixCoords speed= new MatrixCoords(0,0);
        public Turtle(MatrixCoords topLeft, MatrixCoords speed)
            :base(topLeft)
        {
        }
        public override void UpdatePosition()
        {
            this.Speed = speed;
        }

        public override char[,] GetImage()
        {
            char[,] turtle = {
                               { '*', '\u2588', ' ',' ', }, 
                               { ' ', '\u2588', '\u2588' ,'\u2588', }, 
                               { ' ', '\u2588', '\u2588' ,'\u2588',}, 
                               { ' ', '\u2588', ' ' ,'\u2588',}, 
                           };
            return turtle;
        }
    }
}
