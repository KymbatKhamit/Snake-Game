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
    class Food:GameObject
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
        }
    }
}
