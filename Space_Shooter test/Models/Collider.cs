using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class Collider
    {
        public Transform transform;
        public int colliderWidth;
        public int colliderHeight;
        public int layer;
        public int id;

        public Collider(Transform transform, int colliderWidth, int colliderHeight, int layer)
        {
            this.transform = transform;
            this.colliderWidth = colliderWidth;
            this.colliderHeight = colliderHeight;
            this.layer = layer;
        }
    }
}
