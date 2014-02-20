namespace SuperMario
{
    using System;
    using System.Linq;

    public class Hero : IHero
    {
        private int locationX = 50;
        private int locationY = 42;

        public int LocationX
        {
            get
            {
                return this.locationX;
            }
            set
            {
                this.locationX = value;
            }
        }

        public int LocationY
        {
            get
            {
                return this.locationY;
            }
            set
            {
                this.locationY = value;
            }
        }
    }
}
