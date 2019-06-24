using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class Program
    {

        static void Main(string[] args)
        {
            bool gameOver = false;
            ulong sum = 0;
            int obstacles_num = 10;

            Games game = new Games();
            game.Game_init();

            game.Game_create_obstacles(obstacles_num);

            // 多线程
            // 定时器，时隔1秒运行一次Event函数
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;  // 间隔时间1秒 
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Event);

            void Event(object source, System.Timers.ElapsedEventArgs e)
            {
                game.Game_obstacles_move_once();
                if (game.Whether_game_over() == true)   // 是否游戏结束
                {
                    timer.Stop();
                    Console.Clear();
                    game.Game_over();
                    gameOver = true;
                }
                else
                {
                    // 逐渐增加障碍物
                    sum += 1;
                    if (sum % 20 == 0)   // 每10秒生成一组障碍物
                    {
                        obstacles_num += 1;
                        game.Game_create_obstacles(obstacles_num);
                    }
                }
            }

            while (true)
            {
                // 键盘控制与游戏结束
                if (gameOver == true) { break;  }
                else { game.Moving_human(); }
            }

        }
    }
}

