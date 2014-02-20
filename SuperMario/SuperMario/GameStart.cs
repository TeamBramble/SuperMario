namespace SuperMario
{
    using System;

    public class GameStart
    {
        private static void Main()
        {
            RenderEngine.RenderMap();
            Hero superMario = new Hero();
            RenderEngine.RenderHero(superMario);

            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.RightArrow)
                {
                    RenderEngine.RenderHero(superMario, "Right");
                }
                else if (inputKey.Key == ConsoleKey.LeftArrow)
                {
                    RenderEngine.RenderHero(superMario, "Left");
                }
            }
        }
    }
}
