using System;
using System.Text;

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

            PlayArea playArea = new PlayArea();
            Paddle paddle = new Paddle();
            Ball ball = new Ball();

        }
    }
}
