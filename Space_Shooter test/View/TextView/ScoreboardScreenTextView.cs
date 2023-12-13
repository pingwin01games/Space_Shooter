using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Space_Shooter
{
    public class ScoreboardScreenTextView
    {
        bool repeat;

        public void RenderView()
        {
            repeat = true;
            Console.Clear();
            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(Scoreboard.names[i] + ": " + Scoreboard.scores[i].ToString());
            }

            Console.SetCursorPosition(0, 11);
            Console.Write("Click any button to continue.");
            Console.CursorVisible = false;

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

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}
