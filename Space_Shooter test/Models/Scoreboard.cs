using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Space_Shooter
{
    public static class Scoreboard
    {
        public static List<string> names = new List<string>();
        public static List<int> scores = new List<int>();


        public static void addDataScore(string name, int score)
        {
            names.Add(name);
            scores.Add(score);
        }

        public static bool isNewRecord(int score)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                if (score > scores[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static void addScore(string name, int score)
        {
            for (int i = 0; i < scores.Count; i++) 
            {
                if(score > scores[i])
                {
                    for(int j = scores.Count - 1; j > i;  j--)
                    {
                        scores[j] = scores[j - 1];
                        names[j] = names[j - 1];
                    }
                    scores[i] = score;
                    names[i] = name;
                    break;
                }
            }
        }
    }


}
