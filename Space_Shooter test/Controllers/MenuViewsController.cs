using Space_Shooter.View.TextView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class MenuViewsController
    {
        ChooseShipTextView chooseShipTextView = new ChooseShipTextView();
        StartMenuTextView startMenuTextView = new StartMenuTextView();
        GameOverTextView gameOverTextView = new GameOverTextView();
        ScoreboardScreenTextView scoreboardScreenTextView = new ScoreboardScreenTextView();
        BestiaryTextView bestiaryTextView = new BestiaryTextView();


        public int RenderChooseShip()
        {
            //if view == textView
            return chooseShipTextView.RenderView();
        }

        public void RenderMainMenu()
        {
            int decisionId;
            decisionId = startMenuTextView.RenderView();

            if (decisionId == 1)
            {
                Globals.GAMESTATE = GameState.Loading;
                return;
            }

            if (decisionId == 2)
            {
                Globals.GAMESTATE = GameState.ChoosingShip;
                return;
            }

            if(decisionId == 3)
            {
                Globals.GAMESTATE = GameState.BestiaryScreen;
                return;
            }            
            
            if(decisionId == 4)
            {
                Globals.GAMESTATE = GameState.ScoreboardScreen;
                return;
            }


            if (decisionId == 5)
            {
                Environment.Exit(0);
            }
        }

        public void RenderGameOverScreen()
        {
            gameOverTextView.RenderView();
        }

        public void RenderScoreboardScreen()
        {
            scoreboardScreenTextView.RenderView();
        }

        public void RenderBestiaryScreen() 
        {
            bestiaryTextView.RenderView();
        }
    }
}
