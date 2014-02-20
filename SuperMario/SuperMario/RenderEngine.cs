namespace SuperMario
{
    using System;
    using System.Linq;
    using System.Drawing;

    public static class RenderEngine
    {
        private const char Pixel = '\u2588';
        private static readonly int canvasWidth = 340;
        private static readonly int canvasHeight = 58;
        private static readonly int windowWidth = 170;
        private static readonly int windowHeight = 58;
        private static ConsoleColor[,] backgroundColors = new ConsoleColor[canvasWidth, canvasHeight];

        public static void RenderMap()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(windowWidth, windowHeight);
            backgroundColors = GetBitmapColors("..\\..\\images\\Canvas.jpg");

            for (int h = 0; h < canvasHeight; h++)
            {
                for (int w = 0; w < canvasWidth; w++)
                {
                    Console.ForegroundColor = backgroundColors[w, h];
                    Console.Write(Pixel);
                }
                Console.WriteLine();
            }
        }

        public static void RenderHero(Hero hero, string move = "None")
        {
            if (move == "Right")
            {
                ClearHeroSigns(hero, move);
                hero.LocationX++;
            }
            else if (move == "Left")
            {
                ClearHeroSigns(hero, move);
                hero.LocationX--;
            }

            Console.SetCursorPosition(hero.LocationX, hero.LocationY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new String(Pixel, 5));
            Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 1);
            Console.Write(new String(Pixel, 9));
            Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 3));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 2));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 1));
            Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 3));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 3));
            Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 2));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 3));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 3));
            Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 2));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 4));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 4));
            Console.SetCursorPosition(hero.LocationX, hero.LocationY + 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 7));
            Console.SetCursorPosition(hero.LocationX - 3, hero.LocationY + 7);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 2));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new String(Pixel, 10));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new String(Pixel, 2));
            Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new String(Pixel, 3));
            Console.SetCursorPosition(hero.LocationX + 4, hero.LocationY + 8);
            Console.Write(new String(Pixel, 3));
            Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 9);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new String(Pixel, 3));
            Console.SetCursorPosition(hero.LocationX + 5, hero.LocationY + 9);
            Console.Write(new String(Pixel, 3));
        }

        private static ConsoleColor[,] GetBitmapColors(string path)
        {
            ConsoleColor[,] colors = new ConsoleColor[canvasWidth, canvasHeight];
            Bitmap image = new Bitmap(path);
            int widthLimit = image.Width;
            int x = 0;
            int y = 0;

            for (int h = 0; h < 58; h++)
            {
                for (int w = 0; w < 340; w++)
                {
                    colors[w, h] = GetCurrentColor(x, y, image);
                    x += 7;
                    if (x >= widthLimit)
                    {
                        x = 0;
                        y += 11;
                    }
                }
            }
            return colors;
        }

        private static ConsoleColor GetCurrentColor(int x, int y, Bitmap image)
        {
            int r = 0;
            int g = 0;
            int b = 0;

            for (int i = x; i < x + 7; i++)
            {
                for (int j = y; j < y + 11; j++)
                {
                    Color current = image.GetPixel(i, j);
                    r += current.R;
                    g += current.G;
                    b += current.B;
                }
            }
            ConsoleColor color = ClosestConsoleColor(r / 77, g / 77, b / 77);
            return color;
        }

        private static ConsoleColor ClosestConsoleColor(int r, int g, int b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                {
                    return cc;
                }
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            if (ret == ConsoleColor.DarkGray)
            {
                ret = ConsoleColor.Cyan;
            }
            return ret;
        }

        private static void ClearHeroSigns(Hero hero, string direction)
        {
            switch (direction)
            {
                case "Right":                  
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY);
                    Console.ForegroundColor = backgroundColors[hero.LocationX, hero.LocationY];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 1);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 1, hero.LocationY + 1];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 2);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 1, hero.LocationY + 2];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 3);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 2, hero.LocationY + 3];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 4);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 2, hero.LocationY + 4];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 5);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 2, hero.LocationY + 5];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX, hero.LocationY + 6);
                    Console.ForegroundColor = backgroundColors[hero.LocationX, hero.LocationY + 6];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 3, hero.LocationY + 7);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 3, hero.LocationY + 7];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 1, hero.LocationY + 8);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 1, hero.LocationY + 8];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 4, hero.LocationY + 8);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 4, hero.LocationY + 8];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX - 2, hero.LocationY + 9);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 2, hero.LocationY + 9];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 5, hero.LocationY + 9);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 5, hero.LocationY + 9];
                    Console.Write(Pixel);
                    break;
                case "Left":
                    Console.SetCursorPosition(hero.LocationX + 4, hero.LocationY);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 4, hero.LocationY];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 8, hero.LocationY + 1);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 8, hero.LocationY + 1];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 5, hero.LocationY + 2);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 5, hero.LocationY + 2];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 7, hero.LocationY + 3);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 7, hero.LocationY + 3];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 8, hero.LocationY + 4);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 8, hero.LocationY + 4];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 7, hero.LocationY + 5);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 7, hero.LocationY + 5];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 6, hero.LocationY + 6);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 6, hero.LocationY + 6];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 10, hero.LocationY + 7);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 10, hero.LocationY + 7];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 1, hero.LocationY + 8);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 1, hero.LocationY + 8];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 6, hero.LocationY + 8);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 6, hero.LocationY + 8];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX , hero.LocationY + 9);
                    Console.ForegroundColor = backgroundColors[hero.LocationX - 2, hero.LocationY + 9];
                    Console.Write(Pixel);
                    Console.SetCursorPosition(hero.LocationX + 7, hero.LocationY + 9);
                    Console.ForegroundColor = backgroundColors[hero.LocationX + 7, hero.LocationY + 9];
                    Console.Write(Pixel);
                    break;
                default:
                    break;
            }
        }
    }
}
