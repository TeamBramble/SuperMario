namespace SuperMario
{
    using System;
    using System.Linq;
    using System.Drawing;
    using System.IO;

    public static class RenderEngine
    {
        
        private const char Pixel = '\u2588';
        private static int windowsX = 0;
        private static readonly int windowsY = 0;
       
        private static readonly int windowWidth = 100;
        private static readonly int windowHeight = 30;


        public static void RenderMap()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(9999, 300);
            
            using (StreamReader reader = new StreamReader("..\\..\\images\\Background.txt"))
            {
               string[] lines = reader.ReadToEnd().Split('\n');

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(line);
                }
                
            }
            Console.SetWindowPosition(windowsX, windowsY);
        }
        
        public static void RenderEnemy(Enemy enemy, int range)//slagam range dokato napravim collision detection
        {
            
            int i = range;
            if (i > 0)
            {
                while (i > 0)
                {
                    enemy.LocationX--;
                    i -= 1;
                    Console.SetCursorPosition(enemy.LocationX, enemy.LocationY);
                    WriteObject.WriteThis(enemy);
                }
            }
            if (i == 0)
            {
                while (i < range)
                {
                    enemy.LocationX++;
                    i += 1;
                    Console.SetCursorPosition(enemy.LocationX, enemy.LocationY);
                    WriteObject.WriteThis(enemy);
                }
            }
           
            WriteObject.WriteThis(enemy);
        }

        public static void RenderHero(Hero hero, string move = "None")
        {
            if (move == "Right")
            {
                ClearHeroSigns(hero, move);
                hero.LocationX++;
                if (hero.LocationX > (windowWidth / 2))
                {
                    Console.SetWindowPosition(windowsX++, windowsY);
                }
            }
            else if (move == "Left")
            {
                ClearHeroSigns(hero, move);
                hero.LocationX--;       
            }

            Console.SetCursorPosition(hero.LocationX, hero.LocationY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
            Console.SetCursorPosition(hero.LocationX, hero.LocationY+1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
            
        }

        

        

        
        private static void ClearHeroSigns(Hero hero, string direction)
        {
            switch (direction)
            {
                case "Right":                  
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(' ');
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY+1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(' ');
                    break;
                case "Left":
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(' ');
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY+1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(' ');
                    break;
                default:
                    break;
            }
        }
    }
}
