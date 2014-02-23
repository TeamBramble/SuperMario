using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class Mario : GameObject
    {
        private new const string CollisionGroupString = "mario";

        public int Width { get; protected set; }

        public Mario(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
            this.body = GetMyBody();
        }

        public int MarioRow()
        {
            return this.TopLeft.Row;
        }

        public int MarioCol()
        {
            return this.TopLeft.Col;
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
            return otherCollisionGroupString == "brick" || otherCollisionGroupString == Mario.CollisionGroupString || otherCollisionGroupString == "enemy";
        }

        public override void Update()
        {
        }

        /// <summary>
        /// Mario hero visualization
        /// </summary>
        private char[,] GetMyBody()
        {
            char[,] body = {
                               { ' ', ' ', '^', ' ', ' ', }, 
                               { '~', '<', 'O', '>', '~', }, 
                               { ' ', 'o', 'M', 'o', ' ', }, 
                               { ' ', ' ', '=', ' ', ' ', }, 
                               { ' ', '/', '.', '\\', ' ', }, 
                               { '/', ' ', ' ', ' ', '\\', }, 
                           };
            return body;
        }
    }
}
