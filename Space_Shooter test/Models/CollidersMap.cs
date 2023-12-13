using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class CollidersMap
    {
        private int[,,] colliderTable = new int[Globals.COLLIDER_WIDTH,Globals.COLLIDER_HEIGHT,2];

        public CollidersMap() {

            setCollider(new Collider(new Transform(),Globals.COLLIDER_WIDTH,Globals.COLLIDER_HEIGHT,0));

        }

        public void clearCollider(Collider collider)
        {
            for(int i = collider.transform.x; i<collider.colliderWidth+collider.transform.x; i++)
            {
                for(int j = collider.transform.y; j<collider.colliderHeight+collider.transform.y; j++)
                {
                    colliderTable[i, j,0] = 0;
                    colliderTable[i,j,1] = 0;
                }
            }
        }

        public int setCollider(Collider collider)
        {
            for (int i = collider.transform.x; i < collider.colliderWidth + collider.transform.x; i++)
            {
                for (int j = collider.transform.y; j < collider.colliderHeight + collider.transform.y; j++)
                {
                    if(colliderTable[i, j,0] == collider.layer)
                    {
                        return colliderTable[i,j,1];
                    }
                    else
                    {
                        colliderTable[i,j,0] = collider.layer;
                        colliderTable[i, j, 1] = collider.id;
                    };
                }
            }
            return -1;
        }

        public void writeCollider()
        {
            for(int i=0; i<Globals.COLLIDER_HEIGHT; i++)
            {
                Console.Write('\n');
                for (int j=0; j < Globals.COLLIDER_WIDTH; j++)
                {
                    Console.Write(colliderTable[j, i,0]);
                }

            }
        }
    }
}
