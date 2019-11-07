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
        StringBuilder clearBrick = new StringBuilder("     ");


        public Ball()
        {
            Console.SetCursorPosition(CurrentX, CurrentY);
            Console.Write("O"); // \u2588
        }

        public void PutInPlay()
        {
            // Replace this with an on keypress of spacebar type event
            if (Turn > 0)
            {
                Console.SetCursorPosition(26, 33);
                Console.Write("O");
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
                if ((CurrentX == PaddlePosition || CurrentX == PaddlePosition + 1 || CurrentX == PaddlePosition + 2) && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftMovement();
                }
                else if ((CurrentX == PaddlePosition + 4 || CurrentX == PaddlePosition + 5 || CurrentX == PaddlePosition + 6) && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightMovement();
                }
                else if (CurrentX == PaddlePosition + 3 && CurrentY == 34)
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
                    PutInPlay();
                }
            }
        }

        public void DiagonalLeftMovement()
        {
            while (true)
            {
                DidBallHitBrick();
                Thread.Sleep(75);
                //Top hit & continue left
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
                //Continue moving left & upward
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
                //Top hit & continue right
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
                //Continue right
                else if (CurrentX < 49 && CurrentY < 36 && CurrentY > 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                //Right wall hit
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
                //Left wall hit
                if (CurrentX == 2)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightDownMovement();
                }
                //Middle paddle hit
                else if (CurrentX == PaddlePosition + 3 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    UpwardMovement();
                }
                //Paddle hit & continue leftward
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 6 && CurrentX != PaddlePosition + 3 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX--;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftMovement();
                }
                //Continue left-down direction
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                //Out of bounds & resets ball to start
                else if (CurrentY == 36)
                {
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write(" ");
                    Turn++;
                    Thread.Sleep(500);
                    PutInPlay();
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
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalLeftDownMovement();
                }
                else if (CurrentX == PaddlePosition + 3 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    UpwardMovement();
                }
                else if (CurrentX >= PaddlePosition && CurrentX <= PaddlePosition + 6 && CurrentX != PaddlePosition + 3 && CurrentY == 34)
                {
                    PreviousX = CurrentX;
                    CurrentX++;
                    PreviousY = CurrentY;
                    CurrentY--;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                    DiagonalRightMovement();
                }
                else if (CurrentY > 2 && CurrentY < 36)
                {
                    PreviousY = CurrentY;
                    CurrentY++;
                    PreviousX = CurrentX;
                    CurrentX++;
                    DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
                }
                else if (CurrentY == 36)
                {
                    Console.SetCursorPosition(CurrentX, CurrentY);
                    Console.Write(" ");
                    Turn++;
                    Thread.Sleep(500);
                    PutInPlay();
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
            DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
            DiagonalLeftMovement();
        }
        public void PaddleHitRightMovement()
        {
            Thread.Sleep(75);
            PreviousX = CurrentX;
            CurrentX++;
            PreviousY = CurrentY;
            CurrentY--;
            DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
            DiagonalRightMovement();
        }
        public void PaddleHitUpMovement()
        {
            Thread.Sleep(75);
            PreviousX = CurrentX;
            PreviousY = CurrentY;
            CurrentY--;
            DrawBall(PreviousX, PreviousY, CurrentX, CurrentY);
            UpwardMovement();
        }

        //upon hitting a brick method
        public void HitBrick()
        {
            //straight up trajectory
            if (PreviousX == CurrentX && PreviousY >= CurrentY)
            {
                Thread.Sleep(75);
                //puts X out of block
                CurrentX = PreviousX;
                PreviousX = CurrentX;
                //puts Y out of block
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
                if (CurrentY == brick[0] && (CurrentX >= brick[1] && CurrentX <= brick[5]))
                {
                    Breaker(brick);
                    HitBrick();
                    return;
                }
            }
        }

        public void DrawBall(int previousX, int previousY, int currentX, int currentY)
        {
            Console.SetCursorPosition(currentX, currentY);
            Console.Write("O");
            Console.SetCursorPosition(previousX, previousY);
            Console.Write(" ");
        }
        public void Breaker(int[] brick)
        {
            Console.SetCursorPosition(brick[1], brick[0]);
            Console.Write(clearBrick);
            BrickLocation.Remove(brick);
        }
        public bool PlayAgain()
        {
            Console.SetCursorPosition(21, 19);
            Console.Write("Play Again? (y/n)");
            
            while (true)
            {
                ConsoleKeyInfo restart = Console.ReadKey(true);
                if (restart.Key == ConsoleKey.Y)
                {
                    Turn = 0;
                    return true;
                }
                else if (restart.Key == ConsoleKey.N)
                {
                    return false;
                }
            }
        }
    }
}
