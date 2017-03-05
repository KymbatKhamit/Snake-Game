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
    [Serializable]
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
        public void Move()
        {
            for (int i = points.Count - 1; i>0; i--)
            {
                points[i].x = points[i - 1].x;
                points[i].y = points[i - 1].y;
            }
            points[0].x += direction_x;
            points[0].y += direction_y;
            if (points[0].x < 0)
            {
                points[0].x += Program.game_width;
                }
            if (points[0].y < 0)
            {
                points[0].y += Program.game_height;
            }
            if (points[0].x == Program.game_width)
            {
                points[0].x = 0;
            }
            if (points[0].y == Program.game_height)
            {
                points[0].y = 0;
            }
        }
       public void Upgrade()
        {
            Point tmp = new Point(points[points.Count - 1].x, points[points.Count - 1].y);
            AddNewPoint(tmp);
        }
    }
}
