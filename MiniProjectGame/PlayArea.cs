using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectGame
{
    class PlayArea
    {
        //play area should be 50w x 35h
        public void buildBoundries()
        {
            Console.SetCursorPosition(1, 1);
            StringBuilder playArea = new StringBuilder("\u2588"); 
            int count = 0;
            //Builds top boundary, width 50
            while (count++ < 48)
                playArea.Append("\u2580");
            count = 0;
            playArea.AppendLine("\u2588");
            //Builds side boundaries, height 34 for total height 50
            for (int i = 0; i < 34; i++)
            {
                while (count++ < 34)
                {
                    playArea.Append(" \u2588");
                    for (int j = 0; j < 48; j++)
                        playArea.Append(" ");
                    playArea.AppendLine("\u2588");
                }
            }
            count = 0;
            Console.WriteLine(playArea);
        }
    }
}
