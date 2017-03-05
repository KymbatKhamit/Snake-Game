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
    public abstract class GameObject
  
    {
        public char sign;
        public List<Point> points = new List<Point>();
        public ConsoleColor color;
        public void Draw()
        {
            for(int i = 0; i < points.Count; i++)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
                Console.Write(sign);
            }
        }
        public void Clear()
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
                Console.Write(' ');
            }
        }
    }
}
