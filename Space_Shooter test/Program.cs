using System;
using System.Windows.Input;
using System.Windows;
using System.Collections;

namespace Space_Shooter
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.SetWindowSize(Globals.COLLIDER_WIDTH, Globals.COLLIDER_HEIGHT);


            Form1 form = new Form1();

            form.Size = new System.Drawing.Size(1024, 768);
            form.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;

            form.ShowDialog();
    


            FPSController fpsController = new FPSController(60);
            GameObjectsController gameObjectsController = new GameObjectsController();
            MenuViewsController menuViewsController = new MenuViewsController();
            TextSpritesLoader textSpritesLoader = new TextSpritesLoader();
            ScoreboardController scoreboardController = new ScoreboardController();
            
            ShipsData.initData();
            scoreboardController.loadScoreboard();

            PlayerInput playerInput = new PlayerInput(gameObjectsController);

            Console.CursorVisible = false;

            Globals.GAMESTATE = GameState.StartMenu;

            while (true)
            {
                switch (Globals.GAMESTATE)
                {
                    case GameState.StartMenu:
                        menuViewsController.RenderMainMenu();
                        break;

                    case GameState.ChoosingShip:
                        playerInput.addPlayerShip(gameObjectsController.addPlayerShip(menuViewsController.RenderChooseShip()));
                        Globals.GAMESTATE = GameState.Loading;
                        break;

                    case GameState.Loading:

                        gameObjectsController.textViewController.renderWalls();

                        if(playerInput.player == null || playerInput.player.hp <=0)
                        {
                            playerInput.addPlayerShip(gameObjectsController.addPlayerShip(0));
                        }

                        gameObjectsController.textViewController.renderStatistics(playerInput.player.hp);
                        gameObjectsController.moveGameObject(playerInput.player, 0, 0);

                        Globals.GAMESTATE = GameState.PlayArea;
                        break;

                    case GameState.PlayArea:
                      
                        Console.CursorVisible = false;
                        
                        playerInput.movePlayer();
                        gameObjectsController.invokeAllEnviromentMethods();
                        //gameObjectsController.something();
                        fpsController.update();
                        break;

                    case GameState.GameOverScreen:
                        Globals.GAMESTATE = GameState.StartMenu;
                        menuViewsController.RenderGameOverScreen();
                        scoreboardController.saveScoreboard();

                        Globals.CURRENT_SCORE = 0;
                        break;
                    case GameState.ScoreboardScreen:
                        menuViewsController.RenderScoreboardScreen();
                        Globals.GAMESTATE = GameState.StartMenu;
                        break;
                    case GameState.BestiaryScreen:
                        menuViewsController.RenderBestiaryScreen();
                        Globals.GAMESTATE = GameState.StartMenu;
                        break;
                }
            }
        }
    }
}