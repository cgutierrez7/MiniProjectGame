using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjectGame
{
    class Ball
    {
        public int PreviousX { get; set; } = 26;
        public int PreviousY { get; set; } = 33;
        public int CurrentX { get; set; } = 26;
        public int CurrentY { get; set; } = 33;
        public int Turn { get; set; }
        public int PaddlePosition { get; set; }
        public List<int[]> BrickLocation { get; set; }

        public Ball()
        {
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
        }

        public void BallInPlay()
        {
            // Replace this with an on keypress of spacebar type event
            if (Turn > 0)
            {
                Console.SetCursorPosition(26, 33);
                Console.Write("\u2588");
                CurrentX = 26;
                CurrentY = 33;
            }

            ConsoleKeyInfo startBall;
            do
            {
                startBall = Console.ReadKey(true);
            }
            while (startBall.Key != ConsoleKey.Spacebar);
            if (startBall.Key == ConsoleKey.Spacebar)
                UpwardMovement();
        }

        public void UpwardMovement()
        {
            while (true)
            {
                DidBallHitBrick();
                Thread.Sleep(75);
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
                DidBallHitBrick();
                Thread.Sleep(75);
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
                    Turn++;
                    Thread.Sleep(500);
                    BallInPlay();
                }
            }
        }

        public void DiagonalLeftMovement()
        {
            while (true)
            {
                DidBallHitBrick();
                Thread.Sleep(75);
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
                DidBallHitBrick();
                Thread.Sleep(75);
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
                DidBallHitBrick();
                Thread.Sleep(75);
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
                    Turn++;
                    Thread.Sleep(500);
                    BallInPlay();
                    return;
                }
            }
        }

        public void DiagonalRightDownMovement()
        {
            while (true)
            {
                DidBallHitBrick();
                Thread.Sleep(75);
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
                    Turn++;
                    Thread.Sleep(500);
                    BallInPlay();
                    return;
                }
            }
        }

        public void PaddleHitLeftMovement()
        {
            Thread.Sleep(75);
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
            Thread.Sleep(75);
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
            Thread.Sleep(75);
            PreviousX = CurrentX;
            PreviousY = CurrentY;
            CurrentY--;
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("\u2588");
            Console.SetCursorPosition(PreviousX, PreviousY);
            Console.Write(" ");
            UpwardMovement();
        }

        //upon hitting a brick method
        public void HitBrick(int currentX, int currentY)
        {
            //CurrentX = currentX;
            //CurrentY = currentY;
            //Console.WriteLine($"({PreviousX}, {PreviousY})  ({CurrentX}, {CurrentY})");
            //straight up trajectory
            if (PreviousX == CurrentX && PreviousY >= CurrentY)
            {
                Thread.Sleep(75);
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write("\u2588");
                Console.SetCursorPosition(PreviousX, PreviousY);
                Console.Write(" ");
                DownwardMovement();
            }
            //upleft trajectory
            else if (PreviousX > CurrentX && PreviousY > CurrentY)
            {
                Thread.Sleep(75);

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
            //upright trajectory
            else if (PreviousX < CurrentX && PreviousY > CurrentY)
            {
                Thread.Sleep(75);

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
            //downleft trajectory
            else if (PreviousX > CurrentX && PreviousY < CurrentY)
            {
                Thread.Sleep(75);

                PreviousX = CurrentX;
                CurrentX++;
                PreviousY = CurrentY;
                CurrentY++;
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write("\u2588");
                Console.SetCursorPosition(PreviousX, PreviousY);
                Console.Write(" ");
                DiagonalLeftMovement();
            }
            //downright trajectory
            else if (PreviousX < CurrentX && PreviousY < CurrentY)
            {
                Thread.Sleep(75);

                PreviousX = CurrentX;
                CurrentX++;
                PreviousY = CurrentY;
                CurrentY++;
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write("\u2588");
                Console.SetCursorPosition(PreviousX, PreviousY);
                Console.Write(" ");
                DiagonalRightMovement();
            }
        }
        public void DidBallHitBrick()
        {
            foreach (int[] brick in BrickLocation)
            {
                if (CurrentY == brick[0] && (CurrentX >= brick[1] && CurrentX <= brick[5])) // NEED TO CHECK HERE TO SEE IF MAYBE THIS IS WHAT IS CAUSING MESSED UP BRICK COLLISION DETECTION X/Y MIGHT BE OFF
                {
                    //sends location of hit
                    Breaker(brick);
                    HitBrick(CurrentX, CurrentY);
                    return;
                }
            }
        }

        public void DrawBall(int previousX, int previousY, int currentX, int currentY)
        {
            Console.SetCursorPosition(currentX, currentY);
            Console.Write("\u2588");
            Console.SetCursorPosition(previousX, previousY);
            Console.Write(" ");
        }
        public void Breaker(int[] brick)
        {
            Console.SetCursorPosition(brick[1], brick[0]);
            Console.Write("     ");
            BrickLocation.Remove(brick);
        }

    }
}
