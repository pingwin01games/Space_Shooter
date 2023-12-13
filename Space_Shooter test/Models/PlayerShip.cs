using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class PlayerShip: Ship
    {
 
        public PlayerShip (int hp, int xSpeed, int ySpeed,int shootingSpeed, Collider collider, string textSprite,string name)
        {
            this.hp = hp;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.collider = collider;
            type = GameObjectType.PlayerShip;
            this.textSprite = textSprite;
            this.name = name;

            Bullet bullet = new Bullet(0, -1, 1);
            this.bullet = bullet;
            this.bullet.collider.layer = Globals.ENEMIES_LAYER;
            this.shootingSpeed = shootingSpeed;
        }

        public void setBulletSpeed(int xSpeed, int ySpeed)
        {
            bullet.xSpeed = xSpeed;
            bullet.ySpeed = ySpeed;
        }


    }
}
