using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class Mario : GameObject
    {
        public new const string CollisionGroupString = "racket";

        public int Width { get; protected set; }

        public Mario(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
            this.body = GetMyBody();
        }

        /// <summary>
        /// Mario hero visualization
        /// </summary>
        char[,] GetMyBody()
        {
            char[,] body = {
                               { ' ', ' ', '^', ' ', ' ', }, 
                               { ' ', '.', 'O', ')', ' ', }, 
                               { ' ', '.', 'O', ' ', ' ', }, 
                               { ' ', ' ', '=', ' ', ' ', }, 
                               { ' ', '/', ' ', '\\', ' ', }, 
                               { '/', ' ', ' ', ' ', '\\', }, 
                           };
            return body;
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
            return otherCollisionGroupString == "block" || otherCollisionGroupString == Mario.CollisionGroupString || otherCollisionGroupString == "ball";
        }

        public override void Update()
        {
        }
    }
}
