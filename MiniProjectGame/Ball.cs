using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Ball
    {
        int previousX = 0;
        int previousY = 0;
        int currentX = 26;
        int currentY = 34;
        int turn = 1;
        public Ball()
        {
            Console.SetCursorPosition(currentX, currentY);
            Console.Write("\u2588");
            Thread ballThread = new Thread(BallInPlay);
            ballThread.Start();
        }

        void BallInPlay()
        {
            // Replace this with an on keypress of spacebar type event
            ConsoleKeyInfo startBall;
            do
            {
                startBall = Console.ReadKey(true);
            }
            while (startBall.Key != ConsoleKey.Spacebar);
            if (startBall.Key == ConsoleKey.Spacebar)
                //UpwardMovement();
                //DiagonalLeftMovement();
                DiagonalRightMovement();
        }

        void UpwardMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentY > 2)
                {
                    previousY = currentY;
                    currentY--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(currentX, previousY);
                    Console.Write(" ");

                }
                else if (currentY == 2)
                {
                    previousY = currentY;
                    currentY++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(currentX, previousY);
                    Console.Write(" ");
                    DownwardMovement();
                    return;
                }
            }
        }
        void DownwardMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentY > 2 && currentY < 36)
                {
                    previousY = currentY;
                    currentY++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(currentX, previousY);
                    Console.Write(" ");
                }
                else if (currentY == 36)
                {
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write(" ");
                    return;
                }
            }
        }

        void DiagonalLeftMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentY == 2 && currentX > 2)
                {
                    previousX = currentX;
                    currentX--;
                    previousY = currentY;
                    currentY++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalLeftDownMovement();
                }
                else if (currentX > 2 && currentY < 36 && currentY > 2)
                {
                    //Leftward Movement
                    previousX = currentX;
                    currentX--;
                    //Downward Movement
                    previousY = currentY;
                    currentY--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");

                }
                else if (currentX == 2 && currentY > 2)
                {
                    previousX = currentX;
                    currentX++;
                    previousY = currentY;
                    currentY--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalRightMovement();
                }
            }
        }
        void DiagonalRightMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentY == 2 && currentX < 49)
                {
                    previousX = currentX;
                    currentX++;
                    previousY = currentY;
                    currentY++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalRightDownMovement();
                }
                else if (currentX < 49 && currentY < 36 && currentY > 2)
                {
                    //Rightward Movement
                    previousX = currentX;
                    currentX++;
                    //Downward Movement
                    previousY = currentY;
                    currentY--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");

                }
                else if (currentX == 49 && currentY > 2)
                {
                    previousX = currentX;
                    currentX--;
                    previousY = currentY;
                    currentY--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalLeftMovement();
                }
            }
        }

        void DiagonalLeftDownMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentX == 2)
                {
                    previousX = currentX;
                    currentX++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalRightDownMovement();
                }
                if (currentY > 2 && currentY < 36)
                {
                    previousY = currentY;
                    currentY++;
                    previousX = currentX;
                    currentX--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                }
                else if (currentY == 36)
                {
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write(" ");
                    return;
                }
            }
        }

        void DiagonalRightDownMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (currentX == 49)
                {
                    previousX = currentX;
                    currentX--;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                    DiagonalLeftDownMovement();
                }
                if (currentY > 2 && currentY < 36)
                {
                    previousY = currentY;
                    currentY++;
                    previousX = currentX;
                    currentX++;
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(previousX, previousY);
                    Console.Write(" ");
                }
                else if (currentY == 36)
                {
                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write(" ");
                    return;
                }
            }
        }
    }
}
