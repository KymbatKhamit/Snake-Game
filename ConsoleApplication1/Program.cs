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
        static Random rnd;
        public static int game_height;
        public static int game_width;
        static bool game_over;
        static void Main(string[] args)
        {
            game_width = 80;
            game_height = 40;
            Console.SetBufferSize(game_width, game_height + 1);
            Console.SetWindowSize(game_width, game_height + 1);

            game_over = false;
            wall = new Wall();
            food = new Food();
            rnd = new Random();
            snake = new Snake();
            snake.AddNewPoint(GetEmptyPosition());
            for (int i = 0; i < 10; i++)
            {
                wall.AddNewPoint(GetEmptyPosition());
            }
            food.SetNewPosition(GetEmptyPosition());


            drawer = new Thread(Draw);

            drawer.Start();

            while (game_over == false)
            {
                Console.CursorVisible = false;

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.direction_x = 0;
                        snake.direction_y = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.direction_x = 0;
                        snake.direction_y = +1;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.direction_x = -1;
                        snake.direction_y = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.direction_x = +1;
                        snake.direction_y = 0;
                        break;
                    case ConsoleKey.F1:
                        Save();
                        break;
                    case ConsoleKey.F2:
                        drawer.Abort();
                        Load();
                        drawer = new Thread(Draw);
                        drawer.Start();
                        break;
                    default:
                        break;
                }
            }
        }
        static Point GetEmptyPosition()
        {
            Point tmp = new Point();
            while (true)
            {
                tmp.x = rnd.Next(0, game_width);
                tmp.y = rnd.Next(0, game_height);
                if (wall.Intersect(tmp) == false && snake.Intersect(tmp) == false)
                {
                    return tmp;
                }
            }
        }
        static void GameOver()
        {
            game_over = true;
            Console.Clear();
        }

        static void SaveIt(string filename, object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bf.Serialize(fs, obj);
            fs.Close();
        }

        static public object LoadIt(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            object tmp_object = bf.Deserialize(fs) as object;
            fs.Close();
            return tmp_object;
        }

        static void Load()
        {
            wall = LoadIt("1.wall") as Wall;
            food = LoadIt("1.food") as Food;
            snake = LoadIt("1.snake") as Snake;
         
        }

        static void Save()
        {
            SaveIt("1.wall", wall);
            SaveIt("1.food", food);
            SaveIt("1.snake", snake);
        }
        static void Draw()
        {
            Console.Clear();
            wall.Draw();
            food.Draw();
            snake.Draw();

            while (true)
            {
                snake.Clear();

                snake.Move();
                if (snake.Intersect(food))
                {
                    food.Clear();
                    food.SetNewPosition(GetEmptyPosition());
                    food.Draw();

                    snake.Upgrade();
                }
                if (snake.Intersect(wall))
                {
                    GameOver();
                    break;
                }
                snake.Draw();
                Thread.Sleep(250);
            }
        }
    }
}
