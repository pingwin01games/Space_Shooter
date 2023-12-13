using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;

namespace Space_Shooter
{
    public class PlayerInput
    {

        public PlayerShip player;
        GameObjectsController gameObjectsController;
        Stopwatch stopwatch = Stopwatch.StartNew();
        Stopwatch movingStopwatch = Stopwatch.StartNew();

        private long msSincePreviousShot = 0;
        long msSincePreviousMove = 0;

        public PlayerInput(GameObjectsController gameObjectsController)
        {
            this.gameObjectsController = gameObjectsController;
        }

        public void addPlayerShip(PlayerShip playerShip)
        {
            this.player = playerShip;
        }

        public void movePlayer()
        {
            movingStopwatch.Stop();

            msSincePreviousMove += movingStopwatch.ElapsedMilliseconds;

            if (msSincePreviousMove >= 20)
            {
                msSincePreviousMove = 0;

                if (Keyboard.IsKeyDown(Key.A))
                {
                    gameObjectsController.moveGameObject(player, -player.xSpeed, 0);
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    gameObjectsController.moveGameObject(player, player.xSpeed, 0);
                }
                if (Keyboard.IsKeyDown(Key.W))
                {
                    gameObjectsController.moveGameObject(player, 0, -player.ySpeed);
                }
                if (Keyboard.IsKeyDown(Key.S))
                {
                    gameObjectsController.moveGameObject(player, 0, player.xSpeed);
                }
            }

            movingStopwatch.Restart();

            if (Keyboard.IsKeyDown(Key.Space))
            {
                shoot();
            }
        }

        public void shoot()
        {
            stopwatch.Stop();
            msSincePreviousShot += stopwatch.ElapsedMilliseconds;
            if(msSincePreviousShot < player.shootingSpeed || player.collider.transform.y < 6)
            {
                stopwatch.Restart();
                return;
            }
            msSincePreviousShot = 0;

            stopwatch.Restart();

            Bullet spawnedBullet = player.getBullet();
            spawnedBullet.collider.transform.x = player.collider.colliderWidth / 2 + player.collider.transform.x-1;
            spawnedBullet.collider.transform.y = player.collider.transform.y - 2; 
            spawnedBullet.collider.layer = 2;
            gameObjectsController.addGameObject(spawnedBullet);
        }
    }
}
