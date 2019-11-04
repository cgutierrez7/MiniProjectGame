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

        public Game()
        {
            PlayArea = new PlayArea();
            Paddle = new Paddle();
            Ball = new Ball();
        }
        public void PaddleUpdate()
        {
            Ball.PaddlePosition = Paddle.Position;
        }
    }
}
