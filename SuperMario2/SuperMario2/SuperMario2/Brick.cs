﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario2
{
    public class Brick : GameObject
    {
        private new const string CollisionGroupString = "brick";

        public Brick(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
            this.body = GetMyBody();
        }

        public override void Update()
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Mario.CollisionGroupString || otherCollisionGroupString == Enemy.CollisionGroupString; 
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Brick.CollisionGroupString;
        }

        /// <summary>
        ///  Just an exampy to draw brick body
        /// </summary>
        /// <returns></returns>
        private char[,] GetMyBody()
        {
            char[,] body = {
                               { '\u2588', '\u2588', '\u2588', }, 
                               { '\u2588', '\u2588', '\u2588', }, 
                               { '\u2588', '\u2588', '\u2588', }, 
                           };
            return body;
        }
    }
}