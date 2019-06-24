using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class Human
    {
        // 创建人物
        public int[,] Create_human()
        {
            int[,] huaman_array = new int[10, 7];
            // 头
            huaman_array[0, 2] = 4; huaman_array[0, 3] = 4; huaman_array[0, 4] = 4;
            huaman_array[1, 2] = 4; huaman_array[1, 4] = 4;
            huaman_array[2, 2] = 4; huaman_array[2, 3] = 4; huaman_array[2, 4] = 4;
            // 身体
            huaman_array[3, 3] = 4; huaman_array[4, 3] = 4; huaman_array[5, 3] = 4; huaman_array[6, 3] = 4;
            // 左手
            huaman_array[2, 0] = 4; huaman_array[3, 0] = 4; huaman_array[4, 0] = 4; huaman_array[4, 1] = 4; huaman_array[4, 2] = 4;
            // 右手
            huaman_array[4, 4] = 4; huaman_array[4, 5] = 4; huaman_array[4, 6] = 4; huaman_array[5, 6] = 4; huaman_array[6, 6] = 4;
            // 左脚
            huaman_array[7, 0] = 4; huaman_array[7, 1] = 4; huaman_array[7, 2] = 4; huaman_array[8, 0] = 4; huaman_array[9, 0] = 4;
            // 右脚
            huaman_array[7, 3] = 4; huaman_array[8, 3] = 4; huaman_array[9, 3] = 4; huaman_array[9, 4] = 4; huaman_array[9, 5] = 4;

            return huaman_array;
        }

        // 按键对应的功能
        public int[] Key_function(char input, int human_spawn_row, int human_spawn_col)
        {
            int[] array = { human_spawn_row, human_spawn_col};
            switch (input)
            {
                case 'w': array[0]--; break;
                case 's': array[0]++; break;
                case 'a': array[1]--; break;
                case 'd': array[1]++; break;
            }
            // 防止人物跑出边框(不能用else if，没有优先级)
            if (array[0] <= 1)
            {
                array[0] = 1;
            }
            if (array[0] >= 39)
            {
                array[0] = 39;
            }
            if (array[1] <= 1)
            {
                array[1] = 1;
            }
            if (array[1] >= 72)
            {
                array[1] = 72;
            }
            return array;
        }

        // 判断人物是否死亡，撞上障碍物即死亡
        // 障碍物撞上人物，障碍物会覆盖人物，即构成人物的字符数减少，以此判断人物是否撞上障碍物
        public bool Is_dead(int[,] interface_array)
        {
            // 计算构成人物的字符数
            int sum = 0;
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = 0; j < interface_array.GetLength(1); j++)
                {
                    if (interface_array[i, j] == 4)
                    {
                        sum += 1;
                    }
                }
            }
            if (sum != 32) // 人物由32个字符组成
            {
                return true;
            }
            else { return false; }
        }
    }
}

