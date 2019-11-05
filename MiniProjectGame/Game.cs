using System;
using System.Collections.Generic;
using System.Text;

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
        }
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
        public void BrickLocationUpdater()
        {
            Ball.BrickLocation = Bricks.BrickLocation;
        }

        public void DidBallHitBrick()
        {
            foreach (int[] brick in Bricks.BrickLocation)
            {
                if (Ball.CurrentY == brick[0] && (Ball.CurrentX == brick[1] || Ball.CurrentX == brick[2] || Ball.CurrentX == brick[3] || Ball.CurrentX == brick[4] || Ball.CurrentX == brick[5]))
                {
                    ////sends location of hit
                    //Ball.HitBrick(Ball.CurrentX, Ball.CurrentY);
                    //sends the brick array and ball x & y coords at hit location
                    Bricks.Breaker(brick, Ball.CurrentX, Ball.CurrentY);
                    return;
                }
            }
        }
        //Checks for win and sends bool to terminate game
        public bool DidYouWin()
        {
            if (Bricks.BrickLocation.Count == 1)
            {
                return false;
            }
            return true;
        }
    }
}
