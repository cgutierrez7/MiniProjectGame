using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectGame
{
    class Bricks
    {
        public int BrickX { get; set; }
        public int BrickY { get; set; }

        public List<int[]> BrickLocation = new List<int[]>(); 
        StringBuilder renderBrick = new StringBuilder("\u2588\u2588\u2588\u2588\u2588");
        
        public Bricks()
        {
            // [0,0] added so BrickLocation is not empty upon clearing all bricks
            BrickLocation.Add(new int[] { 0, 0 });
            BrickLayout();
        }
        //Turn this into either a randomizer or level selector
        public void BrickLayout()
        {
            for (int i = 5; i < 12; i += 2)
            {
                BrickY = i;
                for (int j = 5; j < 41; j += 7)
                {
                    BrickX = j;
                        Console.SetCursorPosition(BrickX, BrickY);
                        Console.Write(renderBrick);
                        BrickMaker(BrickX, BrickY);
                }
            }
        }
        //adds bricks to BrickLocation list using initial x coord and the follow 4 spaces for a 1x5 brick
        public void BrickMaker(int startX, int y)
        {
            int[] brickCoords = { y, startX, startX + 1, startX + 2, startX + 3, startX + 4 };
            BrickLocation.Add(brickCoords);
        }
    }
}
