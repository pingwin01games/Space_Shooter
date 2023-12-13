using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Space_Shooter.View.TextView
{
    public class BestiaryTextView
    {
        public void RenderView()
        {
            int rowCount = 0;

            int defaultCursorX = 2;
            int defaultCursorY = 1;
            int shipYSize = 12;
            int shipCount = 0;
            int index = 1;

            Console.Clear();

            Console.SetCursorPosition(defaultCursorX, defaultCursorY);

            foreach (EnemyShip ship in ShipsData.enemyShips)
            {
                for (int i = 0; i < ship.textSprite.Length; i++)
                {
                    if (ship.textSprite[i] == '\n')
                    {
                        rowCount++;
                        Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount);
                    }
                    else
                    {
                        Console.Write(ship.textSprite[i]);
                    }

                }

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 2);
                Console.Write(index + ". " + ship.name);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 3);
                Console.Write("HP: " + ship.hp);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 4);
                Console.Write("Rate Of Fire: " + ship.shootingSpeed / 10);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 5);
                Console.Write("Horizontal Speed: " + ship.xSpeed);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 6);
                Console.Write("Vertical Speed: " + ship.ySpeed);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 7);
                Console.Write("Movement Every [ms]: " + ship.movingSpeed);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 9);
                Console.Write("-------------------");


                shipCount++;
                Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount);
                rowCount = 0;
                index++;
            }

            Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount);
            Console.Write("Click any button to continue.");
            Console.CursorVisible = false;

            bool repeat = true;
            while (repeat)
            {
                foreach (Key key in Enum.GetValues(typeof(Key)))
                {
                    if (key != Key.None)
                    {
                        if (Keyboard.IsKeyDown(key))
                            repeat = false;
                    }
                }
            }

        }
    }
}
