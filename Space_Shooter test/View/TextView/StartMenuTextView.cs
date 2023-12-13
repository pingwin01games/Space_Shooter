using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class StartMenuTextView
    {
        int chosenOption;

        public int RenderView()
        {
            chosenOption = 1;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("SPACE SHOOTER");
            Console.SetCursorPosition(0, 2);
            Console.Write("Movement - WSAD :: Shooting - SPACEBAR");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            writeStart();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            writeChoose();
            writeBestiary();
            writeScoreboard();
            writeQuit();

            Console.SetCursorPosition(0, 10);
            Console.Write("Click number of option you want to choose.");
            Console.SetCursorPosition(0, 11);

            while (Console.KeyAvailable)
                Console.ReadKey(true);

            ConsoleKeyInfo enteredKeyID = Console.ReadKey(true);
            int enteredID = (int)enteredKeyID.KeyChar - 48;

            while(enteredKeyID.Key != ConsoleKey.Enter)
            {
                if (enteredKeyID.Key == ConsoleKey.W)
                {
                    if(chosenOption != 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        writeCase(chosenOption);
                        chosenOption--;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        writeCase(chosenOption);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                    if (enteredKeyID.Key == ConsoleKey.S)
                {
                    if(chosenOption != 5)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        writeCase(chosenOption);
                        chosenOption++;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        writeCase(chosenOption);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else
                {

                    if (enteredID >= 6 || enteredID == 0)
                    {
                        Console.SetCursorPosition(0, 11);

                        Console.Write(enteredKeyID.KeyChar + " Choose correct key");
                        Console.SetCursorPosition(0, 9);

                    }
                    else
                    {
                        chosenOption = enteredID;
                        break;
                    }

                }
                enteredKeyID = Console.ReadKey(true);
                enteredID = (int)enteredKeyID.KeyChar - 48;
                Console.CursorVisible = false;
            }
            Console.Clear();
            return chosenOption;

        }

        public void writeStart()
        {
            Console.SetCursorPosition(0, 4);
            Console.Write("1. Start Game");
        }

        public void writeChoose()
        {
            Console.SetCursorPosition(0, 5);
            Console.Write("2. Choose Ship");
        }

        public void writeQuit()
        {
            Console.SetCursorPosition(0, 8);
            Console.Write("5. Quit");
        }

        public void writeScoreboard()
        {
            Console.SetCursorPosition(0, 7);
            Console.Write("4. Scoreboard");
        }

        public void writeBestiary()
        {
            Console.SetCursorPosition(0, 6);
            Console.Write("3. Bestiary");
        }
        public void writeCase(int id)
        {
            switch (id)
            {
                case 1:
                    writeStart();
                    break;
                case 2:
                    writeChoose();
                    break;
                case 3:
                    writeBestiary();
                    break;
                case 4:
                    writeScoreboard();
                    break;
                case 5:
                    writeQuit();
                    break;

            }
            Console.SetCursorPosition(0, 0);

        }
    }
}
