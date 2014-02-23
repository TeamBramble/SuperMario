namespace SuperMario2
{
    using System;
    using System.Linq;

    public class SuperMario2Main
    {
        /// <summary>
        /// Here we setup game start
        /// </summary>
        const int WorldRows = 56;
        const int WorldCols = 1420;

        static void Initialize(Engine engine)
        {
            var brick = new Brick(new MatrixCoords(WorldRows - 3, 10));
            engine.AddObject(brick);

            Mario mario = new Mario(new MatrixCoords(WorldRows - 7, 2));
            engine.AddObject(mario);
        }

        private static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100);

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
