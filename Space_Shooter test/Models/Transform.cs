using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class Transform
    {
        public int x, y;

        public Transform()
        {
            x = 0;
            y = 0;
        }
        public Transform(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
