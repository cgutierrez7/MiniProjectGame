using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectGame
{
    class Paddle
    {
        public Paddle()
        {
            StringBuilder paddle = new StringBuilder("\u2588\u2588\u2588\u2588\u2588");
            Console.CursorVisible = false;
            int x = 23;
            int y = 35;
            Console.SetCursorPosition(x, y);
            Console.Write(paddle);
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
                        Console.SetCursorPosition(x-1, y);
                        Console.Write(" " + paddle);
                        break;
                }
            }

        }
    }
}
