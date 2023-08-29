using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCommander
{
    internal class Grid
    {
        private bool[,] gridArr;
        private Plane[] planes;

        public Grid()
        {
            gridArr = new bool[10,10];
            planes = new Plane[2];
            planes[0] = new Plane();
            planes[1] = new Plane();
        }

        public bool getGridStatus(int x, int y)
        {
            return this.gridArr[x,y];
        }

        public void setGridStatusFalse(int x, int y)
        {
            this.gridArr[x, y] = false;
        }

        public void setGridStatusTrue(int x, int y)
        {
            this.gridArr[x, y] = true;
        }

        public Plane getPlane(int i)
        {
            return this.planes[i];
        }
    } 
}
