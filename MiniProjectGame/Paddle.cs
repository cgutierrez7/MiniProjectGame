using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace MiniProjectGame
{
    class Paddle
    {
        public Paddle()
        {
            Thread paddleThread = new Thread(PaddleMovement);
            paddleThread.Start();
        }
        //Renders and moves paddle left/right based off player input
        public void PaddleMovement()
        {
            StringBuilder paddle = new StringBuilder("\u2588\u2588\u2588\u2588\u2588");
            Console.CursorVisible = false;
            int x = 24;
            int y = 35;
            Console.SetCursorPosition(x, y);
            Console.Write(paddle);
        //Reads input and updates paddle location
            while (true)
            {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                switch (keyPress.Key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        if (x < 2)
                        {
                            x++;
                            break;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(paddle + " ");
                        break;

                    case ConsoleKey.RightArrow:
                        x++;
                        if (x > 45)
                        {
                            x--;
                            break;
                        }
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write(" " + paddle);
                        break;
                }
                //Thread.Sleep(10);
            }
        }
    }
}
