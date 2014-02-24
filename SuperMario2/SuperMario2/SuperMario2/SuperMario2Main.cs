namespace SuperMario2
{
    using System;
    using System.Linq;
    using System.Media;
    using System.Text;

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
            Console.SetWindowSize(GameCols + 2, GameRows + 2);

            // Generate couple briks
            for (int i = 0; i < 10; i++)
            {
                var brick = new Brick(new MatrixCoords(GameRows - 4, rand.Next(10, GameCols - 20)));
                var brick4 = new Brick(new MatrixCoords(GameRows - 4, rand.Next(10, GameCols - 20)));
                engine.AddObject(brick);
                engine.AddObject(brick4);
            }

            var brick2 = new Brick(new MatrixCoords(GameRows - 20, rand.Next(10, 10)));
            var brick5 = new Brick(new MatrixCoords(GameRows - 25, rand.Next(10, 10)));
            engine.AddObject(brick5);

            var brick3 = new Brick(new MatrixCoords(GameRows - 15, rand.Next(10, 10)));
            engine.AddObject(brick3);

            // Generate ten enemies
            //for (int i = 0; i < 10; i++)
            //{
           //     var enemy = new Bomb(new MatrixCoords(rand.Next(5, GameRows - 15), rand.Next(GameRows - 15, GameCols - 2)), new MatrixCoords(1, 0));
           //     engine.AddObject(enemy);
           // }
            for (int i = 0; i < 20; i++)
            {
                var enemy = new Turtle(new MatrixCoords(rand.Next(5, GameRows - 15), rand.Next(GameRows - 15, GameCols - 2)), new MatrixCoords(0, -1));
                engine.AddObject(enemy);
            }
            var theBoss = new SuperEvil(new MatrixCoords(rand.Next(5,GameRows),rand.Next(GameRows,GameCols)),new MatrixCoords(2,-2));
            engine.AddObject(theBoss);
            //var timer = new Timer(new MatrixCoords(1, 1));
            //engine.AddObject(timer);

         //   var displayLives = new DisplayLives(new MatrixCoords(1, 1));
           // engine.AddObject(displayLives);
            var mario = new Mario(new MatrixCoords(GameRows - 20, 2));
            engine.AddObject(mario);
        }

        private static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(GameRows, GameCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100, GameRows, GameCols);

            PutStartingScreen();

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

        private static void PutStartingScreen()
        {
            /*
            string[] bodyAsString = { 
                                        "              ####+###      ",   
                                        "            ##+;';'';'#     ",   
                                        "           ##;;;;;#  ++#    ",   
                                        "          #+;';;'# '  '#    ",   
                                        "         #+;;'';;: ';`##    ",   
                                        "        #+;'';;;'''``'##    ",   
                                        "     :###;;''''##';;;'+###  ",   
                                        "    :#'';;;'#';;';;'';;;;##`",   
                                        "    #';'';'#;'''''''#####+;#",   
                                        "    #;'''###.,';.#...#######",   
                                        "    ##..,###....+#..,##```  ",   
                                        "    #..'.@+#'...##..:##,    ",   
                                        "   .#..`#.##+...':.....##   ",   
                                        "    #...#.#+`.#.........##  ",   
                                        "    #.`#......+#.........#  ",   
                                        "     #:.......+##'.......#  ",   
                                        "     :###:....#++##.....##  ",   
                                        "     `##'#,...#++++#`..##   ",   
                                        "     ,#'+;#@...#++######    ",   
                                        "    `#'''++;;+########+##+# ",   
                                        "    #';;''####'+;#`##      :",   
                                        "   #'#'# #   #+;'#`@'.  '  ,",   
                                        "   #;''`    '# #;#' :,  :  @",   
                                        "   #;;+         +.;   @#   #",   
                                        "   #;'#   @'    #,'`       #",   
                                        "   #;;#       `##,'+       #",   
                                        "    #';#` #+  #;;#`:## #  # ",   
                                        "   #++###    :;;+#    ###'  ",   
                                        " +##+'''#+###;;+''###       ",   
                                        ";#''''+''#;;'##'+''''+      ",   
                                        "#''''''''####''''''''#      ",   
                                        "#''''''''#  #''''''''#      ",   
                                        "#''''''''#  #''''''''#      ",   
                                        "'#''''''#   #'##++###+      ",   
                                        " #;####'#   '####```#       ",   
                                        " #######'        ;+,        ",   
                                    };*/

            string[] bodyAsString = {
                                    "────────────────────────────────────────",
                                    "──────────────────────▒████▒────────────",
                                    "───────────────────░█████▓███░──────────",
                                    "─────────────────░███▒░░░░░░██──────────",
                                    "────────────────▒██▒░░░▒▓▓▓▒░██─────────",
                                    "───────────────▓██░░░▒▓█▒▒▒▓▒▓█─────────",
                                    "──────────────▓█▓─░▒▒▓█─────▓▓█░────────",
                                    "─────────────▓█▒░▒▒▒▒█──▓▓▒▒─▓█▒────────",
                                    "────────────▒█▒░▒▒▒▒▓▒─▒▓▒▓▓─▒█░────────",
                                    "────────────█▓░▒▒▒▒▒▓░─▓▒──░░▒█░────────",
                                    "───────────██░▒▒▒▒▒▒█──▓──░▓████████────",
                                    "──────────░█▒▒▒▒▒▒▒▒▓░─█▓███▓▓▓▓██─█▓───",
                                    "────────▒▓█▓▒▒▒▒▒▒▒▒▓███▓▓████▓▓██──█───",
                                    "──────░███▓▒▒▒▒▓▒▒▒████▒▒░░──████░──██░─",
                                    "──────██▒▒▒▒▒▒▒▒▒▓██▒────────▒██▓────▓█─",
                                    "─────▓█▒▒▒▒▒▒▒▒▓█▓─────▓───▒░░▓──▓────▓█",
                                    "─────██▒▓▒▒▒▒▒█▓──────▒█▓──▓█░▒──▒░────█",
                                    "─────██▒▒▓▓▓▒█▓▓───░──▓██──▓█▓▓▓█▓─────█",
                                    "─────▓█▒██▓▓█▒▒▓█─────░█▓──▒░───░█▓────█",
                                    "─────░██▓───▓▓▒▒▓▓─────░─────────▒▒─░─░█",
                                    "──────▓█──▒░─█▒▓█▓──▒───────░─░───█▒──█▒",
                                    "───────█──░█░░█▓▒──▓██▒░─░─░─░─░░░█▒███─",
                                    "───────█▒──▒▒──────▓██████▓─░░░░─▒██▓░──",
                                    "───────▓█──────────░██▓▓▓██▒─░──░█▒─────",
                                    "────────██▒─────░───░██▓▓▓██▓▒▒▓█▒──────",
                                    "─────────░████▒──░───▒█▓▓▓▓▓████▓───────",
                                    "────────▒▓██▓██▒──░───▓█████▓███────────",
                                    "──────▒██▓░░░░▓█▓░────░█▒█▒─▒▓█▓────────",
                                    "─────▓█▒░░▒▒▒▒▒▓███▓░──▓█▒─▒▓▓█─────────",
                                    "────░█▒░▒████▓██▓▓▓██▒───░▓█▓█░─────────",
                                    "────▓█▒▒█░─▒───▓█▓▓▓▓▓▓▒▒▓█▓█▓──────────",
                                    "────▓█▒█░───────██▓▓▓▓▓█▓▓█▓██──────────",
                                    "────▒█▓▓────────░██▓██▓▓▓▓▓▓▓▓█─────────",
                                    "─────██░────▓▓────█░─█▓▓▓▓▓▓▓─▒█████────",
                                    "─────██░───░──────▓░─▓▓▓▓▓▓▓█─▒█▒░▒██───",
                                    "────▓█░▓░──▓▓────▒█░─█▓▓▓▓▓▓▓█▒─░░░▒██──",
                                    "────█─▒██─░──────████▓▓▓▓▓▓▓█▓─░▒▒█▓▓█░─",
                                    "───▓█─▓▒▓▒░░────▓█▓▓▓▓▓▓▓▓▓▓█░░▒▓█░──▒█─",
                                    "───▒█░█▒▒█▒───░▓█▓▓▓▓▓▓▓▓▓▓█▓░▒▓▓──▓█▓█─",
                                    "───█▓▒▓▒▒▓██████▓▓▓▓▓▓▓▓▓▓▓█▒▒▓▓─░█▓▒▒█░",
                                    "───█░▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▒▒▓─▒█▒▒▒▒█─",
                                    "──▒█─█▒▒▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓─▒█▒▒▒▒██─",
                                    "──▓█─█▒▒▒▒█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▒▓▒░█▒▒▒░▓█──",
                                    "──▓█─█▒▓▒▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒▓░▓░░░░▒█░──",
                                    "──▒█─▓▓▓▓▒▓█▓▓▓▓▓▓▓▓█████▓▓▓▓▒▓░░─▒█▒───",
                                    "───█▒▓▓▓▓▓▒▓██████████░░██▓█─▒█▓▒▓█░────",
                                    "───▓█▒█▓▓▓▓▒▓██░─░▒░─────██▒░▓▓▓▒██─────",
                                    "────████▓▓▓██░───────────▓█░▓▒░░▓█░─────",
                                    "──────░█████░─────────────██▓─▒██░──────",
                                    "───────────────────────────▓███▒────────",
                                    };

            //char[,] marioStart = new char[bodyAsString.Length, bodyAsString[0].Length];
            //for (int i = 0; i < marioStart.GetLength(0); i++)
            //{
            //    for (int j = 0; j < marioStart.GetLength(1); j++)
            //    {
            //        marioStart[i, j] = bodyAsString[i][j];
            //    }
            //}

            SoundPlayer player = new SoundPlayer(@"..\..\properties\start.wav");
            player.Play();

            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();
            for (int t = 10; t < 27; t++)
            {
                for (int i = 0; i < bodyAsString.Length; i++)
                {
                    scene.Append(new string(' ', 2 * t) + bodyAsString[i].Replace('─', ' ') + Environment.NewLine);
                }

                Console.WriteLine(scene.ToString());
                scene.Clear();

                //Thread.Sleep(5);
                Console.Clear();
            }

        }
    }
}
