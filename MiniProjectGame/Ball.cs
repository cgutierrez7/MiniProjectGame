using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Ball
    {
        int prevPosition = 0;
        int currentPosition = 26;

        public Ball()
        {
            ConsoleKeyInfo startBall = Console.ReadKey(true);
            if (startBall.Key == ConsoleKey.Spacebar)
            {
                Thread ballThread = new Thread(BallInPlay);
                ballThread.Start();
            }
        }

        void BallInPlay()
        {
            Console.SetCursorPosition(currentPosition, 33);
            Console.Write("O");
        }
    }
}
