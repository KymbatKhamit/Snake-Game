using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    public class Point
    {
        public int x, y;
        public Point()
        {

        }
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Point tmp = obj as Point;
            if (tmp.x == x && tmp.y == y)
            {
                return true;
            }
            return false;
        }
    }
}
