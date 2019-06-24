using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class Games
    {
        StringBuilder canvas = new StringBuilder();
        int[,] interface_array;
        int[,] human_array;
        char input;
        int[] array;

        // 参数：窗口大小，人物出生点
        int canvas_row = 50;
        int canvas_col = 80;
        int human_spawn_row = 10;
        int human_spawn_col = 10;

        // 实例化
        UI ui = new UI();
        Human human = new Human();
        Obstacle obstacle = new Obstacle();

        // 初始化
        public void Game_init()
        {
            // 输出必要信息
            Console.WriteLine("程序说明：");
            Console.WriteLine("这是一个控制台小游戏；通过参考网上的其它例子和思路仿写；必要注释已经在程序里写上");
            Console.WriteLine('\n');
            Console.WriteLine("开发工具：");
            Console.WriteLine("VS2017；框架：.NET Framework 4.6.1");
            Console.WriteLine('\n');
            Console.WriteLine("游戏玩法：");
            Console.WriteLine("键盘WASD控制人物移动，避开飞来的'#'型的物体，撞到'#'型物体则游戏结束");
            Console.WriteLine("建议：游戏场景有点大，建议终端窗口开全屏");
            Console.WriteLine('\n');
            Console.WriteLine("按下任意键开始游戏。。。。。");
            Console.ReadLine();
            Console.Clear();

            // 初始化
            human_array = human.Create_human();
            interface_array = ui.Set_up_canvas(canvas_row, canvas_col);
            interface_array = ui.Set_up_human(human_spawn_row, human_spawn_col, interface_array, human_array);
            canvas = ui.Transfer_to_StringBuilder(interface_array, canvas);
            Console.WriteLine(canvas);
        }

        // 创造障碍物
        public void Game_create_obstacles(int max_num_of_obstacle)
        {
            interface_array = obstacle.Create_obstacle(canvas_row, canvas_col, max_num_of_obstacle, interface_array);
        }

        // 游戏走一步
        public void Game_obstacles_move_once()
        {
            // 移动障碍物
            interface_array = obstacle.Moving_obstacle(interface_array);
            // 消除到达终点的障碍物
            interface_array = obstacle.Whether_dis_obstacle(canvas_row, canvas_col, interface_array);
            // 显示
            canvas.Clear();
            canvas = ui.Transfer_to_StringBuilder(interface_array, canvas);
            Console.Clear();
            Console.WriteLine(canvas);
        }

        // 使用键盘移动人物一次
        public void Moving_human()
        {
            // 获取人物新位置
            input = Console.ReadKey(true).KeyChar;
            array = human.Key_function(input, human_spawn_row, human_spawn_col);

            human_spawn_row = array[0];
            human_spawn_col = array[1];

            // 清除原有人物
            Console.Clear();
            canvas.Clear();
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = 0; j < interface_array.GetLength(1); j++)
                {
                    if (interface_array[i, j] == 4) { interface_array[i, j] = 0; }
                }
            }

            // 根据新位置重新画过人物
            interface_array = ui.Set_up_human(human_spawn_row, human_spawn_col, interface_array, human_array);
            canvas = ui.Transfer_to_StringBuilder(interface_array, canvas);
            Console.WriteLine(canvas);

        }

        // 游戏是否失败
        public bool Whether_game_over()
        {
            if(human.Is_dead(interface_array) == true) { return true; }
            else { return false; }
        }

        // 游戏结束
        public void Game_over()
        {
            Console.Clear();
            canvas.Clear();

            Console.WriteLine("游戏结束");
            Console.WriteLine("连续按回车键退出。。。。。");
            Console.ReadLine();
        }
    }
}
