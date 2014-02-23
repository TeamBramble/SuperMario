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
            // Generate couple briks
            for (int i = 0; i < 10; i++)
            {
                var brick = new Brick(new MatrixCoords(GameRows - 3, rand.Next(10, GameCols - 20)));
                engine.AddObject(brick);
            }

            var mario = new Mario(new MatrixCoords(GameRows - 7, GameCols - 6));
            engine.AddObject(mario);
        }

        private static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(GameRows, GameCols * 2);
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
