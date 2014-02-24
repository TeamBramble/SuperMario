using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2
{
    public class Turtle:Enemy
    {
        public Turtle(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = GetMyBody();
        }

        public override char[,] GetMyBody()
        {
            char[,] turtleBody = {
                               { '*', ' ',' ', ' ', }, 
                               { ' ', '\u2588','\u2588','\u2588', }, 
                               {  ' ','\u2588', '\u2588','\u2588', }, 
                               {  ' ','\u2588', ' ','\u2588', }, 
                           };
            return turtleBody;
            
        }
    }
}
