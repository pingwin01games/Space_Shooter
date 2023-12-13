using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class EnemySpawnController
    {
        Stopwatch spawningStopwatch = Stopwatch.StartNew();

        long msFromPreviousSpawn = 0;
       public int currentSpawningTime = Globals.STARTING_ENEMY_SPAWN_TIME;

        Random random = new Random();

        public int SpawnEnemy()
        {
            spawningStopwatch.Stop();
            msFromPreviousSpawn += spawningStopwatch.ElapsedMilliseconds;

            if( msFromPreviousSpawn < currentSpawningTime) 
            {
                spawningStopwatch.Restart();
                return -1;
            }

            spawningStopwatch.Restart();
            msFromPreviousSpawn = 0;

            if(currentSpawningTime - Globals.DECREASE_ENEMY_SPAWN_TIME > Globals.MIN_ENEMY_SPAWN_TIME )
            {
                currentSpawningTime -= Globals.DECREASE_ENEMY_SPAWN_TIME;
            }

            int spawnedEnemyID = random.Next(0,ShipsData.enemyShips.Count);

            return spawnedEnemyID;

        }

        public void randomiseSpawnTransform(Transform transform)
        {
            transform.x = random.Next(1, Globals.COLLIDER_WIDTH-10);
            transform.y = 1;
        }
    }
}
