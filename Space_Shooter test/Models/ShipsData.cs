using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public static class ShipsData
    {
        private static PlayerShip playerShip1 = new PlayerShip(3, 2, 2, 500, new Collider(new Transform(Globals.COLLIDER_WIDTH/2,Globals.COLLIDER_HEIGHT - 6), 6, 3, Globals.PLAYER_LAYER), TextViewSprites.PlayerShip1, "Bulldog");
        private static PlayerShip playerShip2 = new PlayerShip(5, 1, 1, 500, new Collider(new Transform(Globals.COLLIDER_WIDTH / 2, Globals.COLLIDER_HEIGHT - 6), 6, 3, Globals.PLAYER_LAYER), TextViewSprites.PlayerShip2, "Rock");
        private static PlayerShip playerShip3 = new PlayerShip(1, 3, 3, 250, new Collider(new Transform(Globals.COLLIDER_WIDTH / 2, Globals.COLLIDER_HEIGHT - 6), 6, 3, Globals.PLAYER_LAYER), TextViewSprites.PlayerShip3, "Mosquito");

        private static EnemyShip enemyShip1 = new EnemyShip(2, 0, 1, 250, 1000, new Collider(new Transform(), 3, 3, Globals.ENEMIES_LAYER), TextViewSprites.EnemyShip1, "Spiky");
        private static EnemyShip enemyShip2 = new EnemyShip(1, 0, 1, 500, 2000, new Collider(new Transform(), 3, 3, Globals.ENEMIES_LAYER), TextViewSprites.EnemyShip2, "Tin Can");
        private static EnemyShip enemyShip3 = new EnemyShip(1, 0, 2, 250, 2000, new Collider(new Transform(), 3, 3, Globals.ENEMIES_LAYER), TextViewSprites.EnemyShip3, "Blockade Runner");

        public static List<PlayerShip> playerShips = new List<PlayerShip>();
        public static List<EnemyShip> enemyShips = new List<EnemyShip>();

/*        public static PlayerShip getPlayerShip1()
        {
            PlayerShip spawnedShip = new PlayerShip(playerShip1.hp, playerShip1.xSpeed, playerShip1.ySpeed, playerShip1.shootingSpeed, playerShip1.collider, playerShip1.textSprite);
            return spawnedShip;
        }

        public static PlayerShip getPlayerShip2()
        {
            PlayerShip spawnedShip = new PlayerShip(playerShip2.hp, playerShip2.xSpeed, playerShip2.ySpeed, playerShip2.shootingSpeed, playerShip2.collider, playerShip2.textSprite);
            return spawnedShip;
        }

        public static PlayerShip getPlayerShip3()
        {
            PlayerShip spawnedShip = new PlayerShip(playerShip3.hp, playerShip3.xSpeed, playerShip3.ySpeed, playerShip3.shootingSpeed, playerShip3.collider, playerShip3.textSprite);
            return spawnedShip;
        }

        public static EnemyShip getEnemyShip1()
        {
            EnemyShip enemyShip = new EnemyShip(enemyShip1.hp, enemyShip1.xSpeed, enemyShip1.ySpeed, enemyShip1.movingSpeed, enemyShip1.shootingSpeed, new Collider(new Transform(5,1),3,3,Globals.ENEMIES_LAYER), enemyShip1.textSprite);
            return enemyShip;
        }
*/
        public static void initData()
        {
            playerShips.Add(playerShip1);
            playerShips.Add(playerShip2);
            playerShips.Add(playerShip3);

            enemyShips.Add(enemyShip1);
            enemyShips.Add(enemyShip2);
            enemyShips.Add(enemyShip3);
        }

        public static PlayerShip getPlayerShip(int id)
        {
            PlayerShip shipTMP = playerShips[id];
            PlayerShip spawnedShip = new PlayerShip(shipTMP.hp, shipTMP.xSpeed, shipTMP.ySpeed, shipTMP.shootingSpeed, shipTMP.collider, shipTMP.textSprite, shipTMP.name);
            return spawnedShip;
        }

        public static EnemyShip getEnemyShip(int id)
        {
            EnemyShip shipTMP = enemyShips[id];
            EnemyShip spawnedShip = new EnemyShip(shipTMP.hp, shipTMP.xSpeed, shipTMP.ySpeed, shipTMP.movingSpeed, shipTMP.shootingSpeed, new Collider(new Transform(5, 1), 3, 3, Globals.ENEMIES_LAYER), shipTMP.textSprite, shipTMP.name);
            return spawnedShip;
        }
    }
}
