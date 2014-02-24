namespace SuperMario2
{
    using System;
    using System.Linq;

    public class SuperMario2Main
    {
        /// <summary>
        /// Here we setup game start
        /// </summary>
        const int GameCols = 170;
        const int GameRows = 56;
        static readonly Random rand = new Random();

        static void Initialize(Engine engine)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Console.SetWindowSize(GameCols, GameRows + 10);
            //Console.SetBufferSize(9999, 300);

            // Generate couple briks
            for (int i = 0; i < 10; i++)
            {
                var brick = new Brick(new MatrixCoords(GameRows - 3, rand.Next(10, GameCols - 20)));
                engine.AddObject(brick);
            }

            // Generate ten turtles
            for (int i = 0; i < 5; i++)
            {
                var enemy = new Turtle(new MatrixCoords(rand.Next(5, GameRows - 10), rand.Next(GameRows - 10, GameCols - 2)), new MatrixCoords(0, -1));
                engine.AddObject(enemy);
            }


            var mario = new Mario(new MatrixCoords(GameRows - 11, 2));
            engine.AddObject(mario);
        }

        private static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(GameRows, GameCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100, GameRows, GameCols);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRight();
            };

            keyboard.OnUpPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerUp();
            };

            keyboard.OnDownPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerDown();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
