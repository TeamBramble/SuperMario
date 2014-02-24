using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class Turtle:Enemy,IEnemy
    {
        public Turtle(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed) { }
        public override char[,] GetImage()
        {
            char[,] turtle = {
                               { '*', '\u2588', ' ', }, 
                               { ' ', '\u2588', '\u2588', }, 
                               { ' ', '\u2588', '\u2588', }, 
                           };
            return turtle;
        }
    }
}
