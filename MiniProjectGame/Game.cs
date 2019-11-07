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
            Thread paddleThread = new Thread(Paddle.PaddleMovement);
            paddleThread.Start();
            Thread ballThread = new Thread(Ball.PutInPlay);
            ballThread.Start();

        }
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
        //Checks for win and sends bool to terminate game
        public bool DidYouWinOrLose()
        {
            if (Bricks.BrickLocation.Count == 1)
            {
                Console.SetCursorPosition(20, 17);
                Console.Write("You Win!!!");
                return Ball.PlayAgain();
            }
            else if (Ball.Turn > 2)
            {
                Console.SetCursorPosition(21, 17);
                Console.Write("You Lose");
                return Ball.PlayAgain();
            }
            return true;
        }
        
        public void PlayAgain()
        {
            Console.SetCursorPosition(21, 19);
            Console.Write("Play Again? (y/n)");
            ConsoleKeyInfo restart;
            do
            {
                restart = Console.ReadKey(true);
            }
            while (restart.Key != ConsoleKey.Y || restart.Key != ConsoleKey.N);
            if (restart.Key == ConsoleKey.Y) 
            {
                Game game = new Game();
            }
            else if (restart.Key == ConsoleKey.N)
            {
                return;
            }
        }

    }
}

