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
        public void AddNewPoint(Point P)
        {
            points.Add(P);
        }
        public bool Intersect(GameObject obj)
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < obj.points.Count; j++)
                {
                    if (points[i].Equals(obj.points[j]))
                    {
                        return true;
                    }
                }
            }
                    return false; 
                }
                public bool Intersect(Point P)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Equals(P)) { 
                    return true;
                }
            }
                return false;
            }
        }
   }
        
   
