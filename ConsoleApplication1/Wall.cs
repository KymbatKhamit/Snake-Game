using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Wall:GameObject
    {
        public Wall()
        {
            color = ConsoleColor.Yellow;
            sign = '#';
        }
        public void AddNewPoint(int _x, int _y)
        {
            points.Add(new Point(_x, _y));
        }
    }
}
