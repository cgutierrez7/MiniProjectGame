using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Game
    {
        public Paddle Paddle { get; set; }
        public Ball Ball { get; set; }
        public PlayArea PlayArea { get; set; }
        public Bricks Bricks { get; set; }

        public Game()
        {
            PlayArea = new PlayArea();
            Paddle = new Paddle();
            Ball = new Ball();
            Bricks = new Bricks();
            Ball.BrickLocation = Bricks.BrickLocation;
        }
        //updates paddle start position to ball class
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
        public bool DidYouWinOrLose()
        {
            if (Bricks.BrickLocation.Count == 1)
            {
                Console.SetCursorPosition(19, 17);
                Console.Write("Board Cleared!");
                Console.SetCursorPosition(16, 18);
                bool response = QuitProgram();
                return response;
            }
            else if (Ball.Turn > 2)
            {
                Console.SetCursorPosition(20, 17);
                Console.Write("You Lose...");
                Console.SetCursorPosition(16, 18);
                bool response = QuitProgram();
                return response;
            }
            return true;
        }
        public bool QuitProgram()
        {
            Console.Write("Play Again? (y/n)\n");
            while (true)
            {
                ConsoleKeyInfo quit = Console.ReadKey(true);
                if (quit.Key == ConsoleKey.Y)
                {
                    Console.SetCursorPosition(15, 17);
                    Console.Write("                             ");
                    Console.SetCursorPosition(15, 18);
                    Console.Write("                             ");
                    Console.SetCursorPosition(15, 17);
                    Console.Write("                             ");
                    return true;
                }
                else if (quit.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(16, 19);
                    Console.Write("You decided to quit");
                    return false;
                }
            }
        }
    }
}
