using System;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(52, 38);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            
            Game game = new Game();
            Thread paddleThread = new Thread(game.Paddle.PaddleMovement);
            paddleThread.Start();
            Thread ballThread = new Thread(game.Ball.BallInPlay);
            ballThread.Start();
            //Loop terminate upon win clearing all bricks now
            while (game.DidYouWinOrLose())
            {
                game.PaddleUpdate();
            }
            ballThread.Interrupt();
            paddleThread.Interrupt();
            Console.Clear();
        }
    }
}
