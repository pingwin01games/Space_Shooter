using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Space_Shooter
{
    public class GameOverTextView
    {
        bool repeat;
        public void RenderView()
        {
            repeat = true;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("GameOver.");
            Console.SetCursorPosition(0, 1);
            Console.Write("Your Score: " + Globals.CURRENT_SCORE);

            if (Scoreboard.isNewRecord(Globals.CURRENT_SCORE))
            {
                Globals.GAMESTATE = GameState.ScoreboardScreen;
                string name;
                Console.SetCursorPosition(0, 2);
                Console.Write("CONGRATULATIONS! Enter your name:");

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                name = Console.ReadLine();

                Scoreboard.addScore(name, Globals.CURRENT_SCORE);
            }

            Console.SetCursorPosition(0, 4);
            Thread.Sleep(200);
            Console.Write("Click any button to continue.");

            while (repeat)
            {
                foreach (Key key in Enum.GetValues(typeof(Key)))
                {
                    if(key != Key.None)
                    {
                        if (Keyboard.IsKeyDown(key))
                            repeat = false;
                    }
                }
            }

            Console.Clear();
        }
    }
}
