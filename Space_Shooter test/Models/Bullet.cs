using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class Bullet : GameObject
    {
        public int damage;
        

        public Bullet(int xSpeed,int ySpeed, int damage) {
            this.damage = damage;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            textSprite = TextViewSprites.Bullet;
            collider = new Collider(new Transform(0,0),2,2,0);
            type = GameObjectType.Bullet;
        }

        public Bullet returnCopy()
        {
            Bullet spawnedBullet = new Bullet(xSpeed,ySpeed,damage);
            spawnedBullet.collider = new Collider(new Transform(collider.transform.x, collider.transform.y),collider.colliderWidth, collider.colliderHeight, collider.layer);
            spawnedBullet.type = GameObjectType.Bullet;
            return spawnedBullet;
        }
    }
}
