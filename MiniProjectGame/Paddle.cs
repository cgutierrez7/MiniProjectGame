using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace MiniProjectGame
{
    class Paddle
    {
        public int Position { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        StringBuilder paddle = new StringBuilder(@"/`._.'\"); //\u2588\u2588\u2588\u2588\u2588

        public Paddle()
        {
            x = 23;
            y = 35;
            Console.SetCursorPosition(x, y);
            Console.Write(paddle);
        }
        //Renders and moves paddle left/right based off player input
        public void PaddleMovement()
        {
            Console.CursorVisible = false;
            Position = x;
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
                        if (x > 43)
                        {
                            x--;
                            break;
                        }
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write(" " + paddle);
                        break;
                }
                Position = x;
            }
        }
    }
}
