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
                PreviousX = 26;
                PreviousY = 33;
                CurrentX = 26;
                CurrentY = 33;
            }

            while (true)
            {
                ConsoleKeyInfo startBall = Console.ReadKey(true);
                if (startBall.Key == ConsoleKey.Spacebar)
                {
                    UpwardMovement();
                    return;
                }
            }
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                else if (CurrentY == 2)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DownwardMovement();
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftMovement();
                }
                else if ((CurrentX == PaddlePosition + 3 || CurrentX == PaddlePosition + 4) && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightMovement();
                }
                else if (CurrentX == PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    UpwardMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftDownMovement();
                }
                //Top left corner hit
                else if (CurrentY == 2 && CurrentX == 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightDownMovement();
                }
                //Continue upward & left
                else if (CurrentX > 2 && CurrentY < 36 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                //Collision with Left Wall, but continue upward
                else if (CurrentX == 2 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightDownMovement();
                }
                //Top right corner hit
                else if (CurrentY == 2 && CurrentX == 49)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftDownMovement();
                }
                else if (CurrentX < 49 && CurrentY < 36 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                else if (CurrentX == 49 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightDownMovement();
                }
                else if (CurrentX == PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    UpwardMovement();
                }
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 4 && CurrentX != PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
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
                //Right wall hit
                if (CurrentX == 49)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftDownMovement();
                }
                //Middle paddle hit
                else if (CurrentX == PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    UpwardMovement();
                }
                //Paddle hit, keeps trajectory
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 4 && CurrentX != PaddlePosition + 2 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightMovement();
                }
                //Continues down right
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                //Out of play
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
        //upon hitting a brick method
        public void HitBrick()
        {
            //straight up trajectory
            if (PreviousX == CurrentX && PreviousY >= CurrentY)
            {
                Thread.Sleep(75);
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                CurrentY = PreviousY;
                PreviousY = CurrentY;
                CurrentY++;
                DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                DownwardMovement();
            }
            //upleft trajectory
            else if (PreviousX > CurrentX && PreviousY > CurrentY)
            {
                Thread.Sleep(75);
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                CurrentX--;
                CurrentY = PreviousY;
                PreviousY = CurrentY;
                CurrentY++;
                DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                DiagonalLeftDownMovement();
            }
            //upright trajectory
            else if (PreviousX < CurrentX && PreviousY > CurrentY)
            {
                Thread.Sleep(75);
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                CurrentX++;
                CurrentY = PreviousY;
                PreviousY = CurrentY;
                CurrentY++;
                DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                DiagonalRightDownMovement();
            }
            //downleft trajectory
            else if (PreviousX > CurrentX && PreviousY < CurrentY)
            {
                Thread.Sleep(75);
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                CurrentX--;
                CurrentY = PreviousY;
                PreviousY = CurrentY;
                CurrentY--;
                DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                DiagonalLeftMovement();
            }
            //downright trajectory
            else if (PreviousX < CurrentX && PreviousY < CurrentY)
            {
                Thread.Sleep(75);
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                CurrentX++;
                CurrentY = PreviousY;
                PreviousY = CurrentY;
                CurrentY--;
                DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
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
                    HitBrick();
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
