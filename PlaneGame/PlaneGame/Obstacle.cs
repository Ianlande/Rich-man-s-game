using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class Obstacle
    {
        int obstacle_location_row;
        int obstacle_num;

        // 随机生成障碍物；使用随机数，随机生成数量的障碍物，生成位置也随机
        public int[,] Create_obstacle(int canvas_row, int canvas_col, int max_num_of_obstacle, int[,] interface_array)
        {
            Random random = new Random();
            // 左墙壁生成障碍物
            obstacle_num = random.Next(1, max_num_of_obstacle); // 生成障碍物的最大数量
            for (int i = 0; i < obstacle_num; i++)
            {
                obstacle_location_row = random.Next(1, canvas_row - 2); // 障碍物生成的位置
                interface_array[obstacle_location_row, 1] = 5;
            }
            return interface_array;
        }

        // 障碍物移动
        public int[,] Moving_obstacle(int[,] interface_array)
        {
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = interface_array.GetLength(1) - 1; j >= 0; j--)
                {
                    if (interface_array[i, j] == 5)
                    {
                        interface_array[i, j + 1] = 5;
                        interface_array[i, j] = 0;
                    }
                }
            }
            return interface_array;
        }

        // 障碍物消失规则：移动到右边墙壁就消失
        public int[,] Whether_dis_obstacle(int canvas_row, int canvas_col, int[,] interface_array)
        {
            for (int i = 0; i < canvas_row; i++)
            {
                if (interface_array[i, canvas_col - 2] == 5) { interface_array[i, canvas_col - 2] = 0; }
            }
            return interface_array;
        }

    }
}
