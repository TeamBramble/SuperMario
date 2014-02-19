namespace SuperMario
{
    using System;
    using System.Linq;
    using System.Drawing;

    public class RenderEngine
    {
        public static void Render()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(170, 58);
            ConsoleColor[,] colors = GetBitmapColors("..\\..\\images\\Canvas.jpg");

            char pixel = '\u2588';
            for (int h = 0; h < 58; h++)
            {
                for (int w = 0; w < 340; w++)
                {
                    Console.ForegroundColor = colors[w, h];
                    Console.Write(pixel);
                }
                Console.WriteLine();
            }
        }

        static ConsoleColor[,] GetBitmapColors(string path)
        {
            ConsoleColor[,] colors = new ConsoleColor[340, 58];
            Bitmap image = new Bitmap(path);
            int widthLimit = 2380;
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

        static ConsoleColor GetCurrentColor(int x, int y, Bitmap image)
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

        static ConsoleColor ClosestConsoleColor(int r, int g, int b)
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
    }
}
