using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class EnemyShip : Ship
    {

        Stopwatch movingStopwatch = Stopwatch.StartNew();
        Stopwatch shootingStopwatch = Stopwatch.StartNew();

        public int movingSpeed;

        long msSincePreviousMove = 0;
        long msSincePreviousShot = 0;

        int savedXSpeed;
        int savedYSpeed;

        public EnemyShip(int hp, int xSpeed, int ySpeed, int movingSpeed, int shootingSpeed, Collider collider, string textSprite, string name)
        {
            this.hp = hp;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.savedXSpeed = xSpeed;
            this.savedYSpeed = ySpeed;
            this.collider = collider;
            type = GameObjectType.EnemyShip;
            this.textSprite = textSprite;
            this.name = name;

            this.bullet = new Bullet(0,1,1);
            this.bullet.collider.layer = Globals.PLAYER_LAYER;
            this.shootingSpeed = shootingSpeed;
            this.movingSpeed = movingSpeed;
        }

        public void move()
        {

            movingStopwatch.Stop();
            msSincePreviousMove += movingStopwatch.ElapsedMilliseconds;
            if (msSincePreviousMove < movingSpeed)
            {
                xSpeed = 0;
                ySpeed = 0;
                movingStopwatch.Restart();
                return;
            }
            msSincePreviousMove = 0;

            shootingStopwatch.Restart();

            xSpeed = savedXSpeed;
            ySpeed = savedYSpeed;
        }

        public Bullet shoot()
        {
            shootingStopwatch.Stop();
            msSincePreviousShot += shootingStopwatch.ElapsedMilliseconds;
            if (msSincePreviousShot < shootingSpeed)
            {
                shootingStopwatch.Restart();
                return null;
            }

            if (collider.transform.y > Globals.COLLIDER_HEIGHT - 15)
                return null;

            msSincePreviousShot = 0;

            shootingStopwatch.Restart();

            Bullet spawnedBullet = getBullet();
            spawnedBullet.collider.transform.x = collider.colliderWidth / 2 + collider.transform.x - 1;
            spawnedBullet.collider.transform.y = collider.transform.y + collider.colliderHeight + 1;
            spawnedBullet.collider.layer = Globals.PLAYER_LAYER;

            return spawnedBullet;
        }
    }
}
