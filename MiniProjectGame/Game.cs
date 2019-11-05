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
            BrickLocationUpdater();
        }
        //updates paddle start position to ball class
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
        //sends updated list from brick class to ball class
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
                    //sends the brick array and ball x & y coords at hit location
                    Bricks.Breaker(brick, Ball.CurrentX, Ball.CurrentY);
                    BrickLocationUpdater();
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
