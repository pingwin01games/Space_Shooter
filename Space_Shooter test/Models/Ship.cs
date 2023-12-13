using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class Ship :GameObject
    {
        public int hp;
        protected Bullet bullet;
        public int shootingSpeed;
        public string name;

        
        public bool getDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                return true;
            }
            else
                return false;
        }

        public Bullet getBullet()
        {
            return bullet.returnCopy();
        }
    }


}
