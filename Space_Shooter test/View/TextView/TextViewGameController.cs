using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class TextViewGameController
    {
        public void moveObject(GameObject go, int x, int y)
        {
            int rowCount = 0;

            clearObject(go);

            go.collider.transform.x += x;
            go.collider.transform.y += y;

            Console.SetCursorPosition(go.collider.transform.x, go.collider.transform.y);

            for (int i = 0;i<go.textSprite.Length;i++)
            {
                if (go.textSprite[i] ==  '\n')
                {
                    rowCount++;
                    Console.SetCursorPosition(go.collider.transform.x, go.collider.transform.y + rowCount);
                }
                else
                {
                    Console.Write(go.textSprite[i]);
                }
            }
        }

        public void clearObject(GameObject go)
        {
            Console.SetCursorPosition(go.collider.transform.x, go.collider.transform.y);
            for (int i = 0; i < go.collider.colliderHeight; i++)
            {
                Console.SetCursorPosition(go.collider.transform.x, go.collider.transform.y + i);
                for (int j = 0; j < go.collider.colliderWidth; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        public void renderWalls()
        {
            Console.SetCursorPosition(0, 0);
            for(int i=0; i< Globals.COLLIDER_HEIGHT + 1; i++)
            {
                for(int j=0; j< Globals.COLLIDER_WIDTH + 1; j++) {

                    if (i == 0|| i == Globals.COLLIDER_HEIGHT)
                    {
                        Console.Write("x");
                    }
                    else
                        if(j == 0)
                    {
                        Console.Write("x");
                    }
                    else if(j == Globals.COLLIDER_WIDTH)
                    {
                        Console.SetCursorPosition(j,i);
                        Console.Write("x");
                    }
                    
                }
                Console.SetCursorPosition(0, i);

            }
        }

        public void renderStatistics(int maxHP)
        {
            Console.SetCursorPosition(Globals.COLLIDER_WIDTH+2, 1);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("HP");

            Console.BackgroundColor= ConsoleColor.Black;
            Console.Write(" " + maxHP);
            Console.SetCursorPosition(Globals.COLLIDER_WIDTH + 2, 2);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Current Score:");
            Console.BackgroundColor= ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + +Globals.CURRENT_SCORE);
        }

        public void updateHP(int hp)
        {
            Console.SetCursorPosition(Globals.COLLIDER_WIDTH + 5, 1);
            Console.Write(hp);
        }

        public void updateScore()
        {
            Console.SetCursorPosition(Globals.COLLIDER_WIDTH + 17, 2);
            Console.Write(Globals.CURRENT_SCORE);
        }
    }
}
