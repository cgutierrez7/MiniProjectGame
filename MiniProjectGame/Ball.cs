using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Ball
    {
        public int PreviousX { get; set; } = 0;
        public int PreviousY { get; set; } = 0;
        public int CurrentX { get; set; } = 27;
        public int CurrentY { get; set; } = 33;
        public int Turn { get; set; }
        public int PaddlePosition { get; set; }

        public List<int[]> BrickLocation = new List<int[]>();

        public Ball()
        {
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
        }

        public void BallInPlay()
        {
            // Replace this with an on keypress of spacebar type event
            ConsoleKeyInfo startBall;
            do
            {
                startBall = Console.ReadKey(true);
            }
            while (startBall.Key != ConsoleKey.Spacebar);
            if (startBall.Key == ConsoleKey.Spacebar)
                DiagonalRightMovement();
        }

        public void UpwardMovement()
        {
            while (true)
            {
                //DidBallHitBrick();
                Thread.Sleep(100);
                if (CurrentY > 2)
                {
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(CurrentX, PreviousY);
                    Console.Write(" ");

                }
                else if (CurrentY == 2)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(CurrentX, PreviousY);
                    Console.Write(" ");
                    DownwardMovement();
                    return;
                }
            }
        }
        public void DownwardMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                //DidBallHitBrick();
                if ((CurrentX == PaddlePosition || CurrentX == PaddlePosition + 1) && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalLeftMovement();
                }
                else if ((CurrentX == PaddlePosition + 3 || CurrentX == PaddlePosition + 4) && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalRightMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(CurrentX, PreviousY);
                    Console.Write(" ");
                }

                else if (CurrentY == 36)
                {
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write(" ");
                    return;
                }
            }
        }

        public void DiagonalLeftMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                //DidBallHitBrick();
                //Top wall hit, but still continue moving left
                if (CurrentY == 2 && CurrentX > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalLeftDownMovement();
                }
                //Continue moving left & upward
                else if (CurrentX > 2 && CurrentY < 36 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                }
                //Collision with Left Wall, but continue upward
                else if (CurrentX == 2 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalRightMovement();
                }
            }
        }
        public void DiagonalRightMovement()
        {
            while (true)
            {
                //DidBallHitBrick();
                Thread.Sleep(100);
                if (CurrentY == 2 && CurrentX < 49)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalRightDownMovement();
                }
                else if (CurrentX < 49 && CurrentY < 36 && CurrentY > 2)
                {
                    //Rightward Movement
                    PreviousX = CurrentX;
                    CurrentX++;
                    //Downward Movement
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");

                }
                else if (CurrentX == 49 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalLeftMovement();
                }
            }
        }

        public void DiagonalLeftDownMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
               // DidBallHitBrick();
                if (CurrentX == 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalRightDownMovement();
                }
                else if (CurrentX == PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    //CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    UpwardMovement();
                }
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 4 && CurrentX != PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalLeftMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                }
                else if (CurrentY == 36)
                {
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write(" ");
                    return;
                }
            }
        }

        public void DiagonalRightDownMovement()
        {
            while (true)
            {
                Thread.Sleep(100);
                //DidBallHitBrick();
                if (CurrentX == 49)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalLeftDownMovement();
                }
                else if (CurrentX == PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    //CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    UpwardMovement();
                }
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 4 && CurrentX != PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                    DiagonalRightMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX++;
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write("\u2588");
                    Console.SetCursorPosition(PreviousX, PreviousY);
                    Console.Write(" ");
                }
                else if (CurrentY == 36)
                {
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write(" ");
                    return;
                }
            }
        }

        public void PaddleHitLeftMovement()
        {
            Thread.Sleep(100);
            PreviousX = CurrentX;
            CurrentX--;
            PreviousY = CurrentY;
            CurrentY--;
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
            Console.SetCursorPosition(PreviousX, PreviousY);
            Console.Write(" ");
            DiagonalLeftMovement();
        }
        public void PaddleHitRightMovement()
        {
            Thread.Sleep(100);
            PreviousX = CurrentX;
            CurrentX++;
            PreviousY = CurrentY;
            CurrentY--;
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
            Console.SetCursorPosition(PreviousX, PreviousY);
            Console.Write(" ");
            DiagonalRightMovement();
        }
        public void PaddleHitUpMovement()
        {
            Thread.Sleep(100);
            PreviousX = CurrentX;
            PreviousY = CurrentY;
            CurrentY--;
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
            Console.SetCursorPosition(PreviousX, PreviousY);
            Console.Write(" ");
            UpwardMovement();
        }
        public void HitBrick(int currentX, int currentY)
        {
            CurrentX = currentX;
            CurrentY = currentY;
            
            if (CurrentX < PreviousX && CurrentY < PreviousY)
            {
                PreviousX = CurrentX;
                CurrentX++;
                PreviousY = CurrentY;
                CurrentY++;
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write("\u2588");
                Console.SetCursorPosition(PreviousX, PreviousY);
                Console.Write(" ");
                DiagonalLeftDownMovement();
            }
        }
        public void DidBallHitBrick()
        {
            foreach (int[] brick in BrickLocation)
            {
                if (CurrentY == brick[0] && CurrentX >= brick[1] && CurrentX <= brick[3])
                {
                    //sends location of hit
                    HitBrick(CurrentX, CurrentY);
                }
            }
        }

    }
}
