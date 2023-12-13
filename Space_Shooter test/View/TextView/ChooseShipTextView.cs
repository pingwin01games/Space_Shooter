using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Space_Shooter
{
    public class ChooseShipTextView
    {
        public int RenderView()
        {
            int rowCount = 0;

            int defaultCursorX = 2;
            int defaultCursorY = 1;
            int shipYSize = 12;
            int shipCount = 0;
            int index = 1;

            Console.Clear();

            Console.SetCursorPosition(defaultCursorX, defaultCursorY);

            foreach (PlayerShip ship in ShipsData.playerShips)
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
                Console.Write(index+". "+ ship.name);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 3);
                Console.Write("HP: " + ship.hp);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 4);
                Console.Write("Rate Of Fire: " + ship.shootingSpeed/10);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 5);
                Console.Write("Horizontal Speed: " + ship.xSpeed);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 6);
                Console.Write("Vertical Speed: " + ship.ySpeed);

                Console.SetCursorPosition(defaultCursorX, defaultCursorY + rowCount + shipYSize * shipCount + 8);
                Console.Write("-------------------");


                shipCount++;
                Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount);
                rowCount = 0;
                index++;
            }

            Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount);
            Console.Write("Choose your ship by entering it's number. And play!");

            Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount + 1);

            
            ConsoleKeyInfo enteredKeyID = Console.ReadKey();
            int enteredID = (int)enteredKeyID.KeyChar - 48;

            while (enteredID >= index || enteredID == 0)
            {
                Console.SetCursorPosition(defaultCursorX + 2, defaultCursorY + shipYSize * shipCount + 1);

                Console.Write("Choose correct number");
                Console.SetCursorPosition(defaultCursorX, defaultCursorY + shipYSize * shipCount + 1);

                enteredKeyID = Console.ReadKey();
                enteredID = (int)enteredKeyID.KeyChar - 48;
            }

            Console.Clear();
            return enteredID -1;

        }
    }
}
