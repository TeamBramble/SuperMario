namespace SuperMario
{
    using System;
    using System.Linq;

    public class Hero : IHero//,IMovable
    {
        private int locationX = 10;
        private int locationY = 21;

        /* taka moje da izglejda Moving() za hero, ako oprostim renderEngine-a
        public void Moving()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey();
            if (inputKey.Key == ConsoleKey.RightArrow)
            {
                RenderEngine.RenderHero("Right");
            }
            else if (inputKey.Key == ConsoleKey.LeftArrow)
            {
                RenderEngine.RenderHero("Left");
            }
        }
         */
      public void MovingHero(Hero mario)
        {
            ConsoleKeyInfo inputKey = Console.ReadKey();
            if (inputKey.Key == ConsoleKey.RightArrow)
            {
                RenderEngine.RenderHero(mario,"Right");
            }
            else if (inputKey.Key == ConsoleKey.LeftArrow)
            {
                RenderEngine.RenderHero(mario,"Left");
            }
        }
        
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
