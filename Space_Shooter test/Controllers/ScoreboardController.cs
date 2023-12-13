using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class ScoreboardController
    {

        string workingDirectory = Environment.CurrentDirectory;
        string scoreboardPath = @"Assets\Data\Scoreboard.txt";
        string projectDirectory;

        public ScoreboardController()
        {
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            scoreboardPath = Path.Combine(projectDirectory, scoreboardPath);
        }
        public void  loadScoreboard()
        {
            string temporaryScoreboard = File.ReadAllText(scoreboardPath);
            string name = "";
            int score = 0;
            int numberCounter;

            for(int i = 0; i < temporaryScoreboard.Length; i++)
            {
                if (temporaryScoreboard[i] == ':')
                {
                    numberCounter = i + 2;
                    while (temporaryScoreboard[numberCounter] != ';')
                    {
                        score *= 10;
                        score += temporaryScoreboard[numberCounter] - 48;
                        numberCounter++;
                    }

                    Scoreboard.addDataScore(name, score);
                    name = "";
                    score = 0;
                    i = numberCounter;
                }
                else
                {
                    name += temporaryScoreboard[i];
                }
            }
        }

        public void saveScoreboard()
        {
            string savedScoreboard = "";

            for(int i=0; i < 10; i++)
            {
                savedScoreboard += Scoreboard.names[i] + ": " + Scoreboard.scores[i] +";";
            }
            File.WriteAllText(scoreboardPath, savedScoreboard);

        }
    }
}
