﻿using System;
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
            Ball.BrickLocation = Bricks.BrickLocation;
        }
        //updates paddle start position to ball class
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
        public bool DidYouWinOrLose()
        {
            if (Bricks.BrickLocation.Count == 1)
            {
                return false;
            }
            else if (Ball.Turn > 2)
            {
                return false;
            }
            return true;
        }

    }
}
