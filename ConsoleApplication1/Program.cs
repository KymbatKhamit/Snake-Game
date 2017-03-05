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
    class Program
    {
        static Food food;
        static Wall wall;
        static Snake snake;
        static Thread drawer;
        public static int game_height;
        public static int game_width;
        static void Main(string[] args)
        {
            game_width = 80;
            game_height = 40;
            Console.SetBufferSize(game_width, game_height + 1);
            Console.SetWindowSize(game_width, game_height + 1);
        }
    }
}
