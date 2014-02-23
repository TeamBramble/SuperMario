namespace SuperMario
{
    using System;

    public class GameStart
    {
        private static void Main()
        {
            RenderEngine.RenderMap();
            Hero superMario = new Hero();
            //test na rendvaneto na kostenurka
            Turtle turtle = new Turtle(500, 100, 42);
            

            //RenderEngine.RenderHero(superMario);

            while (true)
            {
                //turtle.Moving();
              //  superMario.MovingHero(superMario);
            }
           
        }
    }
}
