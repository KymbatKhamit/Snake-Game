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
    class Snake:GameObject
    {
        public int direction_x;
        public int direction_y;
        public Snake()
        {
            color = ConsoleColor.White;
            sign = '@';
            direction_x = 1;
            direction_y = 0;
        }
    }
}
