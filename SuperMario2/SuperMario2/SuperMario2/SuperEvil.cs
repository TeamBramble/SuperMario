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
        private new const string CollisionGroupString = "boss";

        public SuperEvil(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed) { }

        //TO DO да се override-не долният метод, така че да не фрийзва това Enemy
        protected override void UpdatePosition()
        {
            if (hasMovedUp && this.TopLeft.Row > 30)
            {
                this.TopLeft = MatrixCoords.Set(this.TopLeft, this.TopLeft.Row - this.Speed.Row-5, this.TopLeft.Col + this.Speed.Col);
            }
            else hasMovedUp = false;
            if (!hasMovedUp && this.TopLeft.Row<40)
            {
                this.TopLeft = MatrixCoords.Set(this.TopLeft, this.TopLeft.Row + this.Speed.Row, this.TopLeft.Col + this.Speed.Col);
            }
            hasMovedUp = true;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }

        public override string GetCollisionGroupString()
        {
            return SuperEvil.CollisionGroupString;
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
