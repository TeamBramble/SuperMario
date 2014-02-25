using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2
{
    public class Bomb : Enemy
    {
        private new const string CollisionGroupString = "bomb";

        public Bomb(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = GetMyBody();
        }
        public override string GetCollisionGroupString()
        {
            return Bomb.CollisionGroupString;
        }
       
    }
}
