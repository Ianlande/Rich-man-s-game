using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class UI
    {
        // 创建UI界面；输入：界面的长宽；输出：一个二维数组
        public int[,] Set_up_canvas(int canvas_row, int canvas_col)
        {
            int[,] interface_array = new int[canvas_row, canvas_col];

            // 画边框
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = 0; j < interface_array.GetLength(1); j++)
                {
                    if (i == 0 ||  i == interface_array.GetLength(0)-1)
                    {
                        interface_array[i, j] = 1;
                    }
                    else if (j == 0 || j == interface_array.GetLength(1) - 1)
                    {
                        interface_array[i, j] = 2;
                    }
                }
            }
            interface_array[0, 0] = 3;
            interface_array[canvas_row - 1, 0] = 3;
            interface_array[0, canvas_col - 1] = 3;
            interface_array[canvas_row - 1, canvas_col - 1] = 3;

            return interface_array;
        }

        // 在UI界面中画人物；人物也是一个二维数组；spawn_row/int spawn_col是人物的生成点坐标
        public int[,] Set_up_human(int spawn_row, int spawn_col, int[,] interface_array, int[,] human_array)
        {
            for (int i = 0; i < human_array.GetLength(0); i++)
            {
                for (int j = 0; j < human_array.GetLength(1); j++)
                {
                    if(interface_array[spawn_row + i, spawn_col + j] != 5)  //5表示障碍物，确保人物的移动不会覆盖障碍物
                    {
                        interface_array[spawn_row + i, spawn_col + j] = human_array[i, j];
                    }
                }
            }
            return interface_array;
        }

        // 显示UI界面
        // UI界面二维数组专门有一个StringBuilder类的字符串数组来一一对应，在运算时是对数组进行运算，而输出则是输出StringBuilder类字符型数组
        // 使用StringBuilder是因为StringBuilder类比String类效率高
        public StringBuilder Transfer_to_StringBuilder(int[,] interface_array, StringBuilder canvas)
        {
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = 0; j < interface_array.GetLength(1); j++)
                {
                    switch (interface_array[i, j])
                    {
                        case 1:  canvas.Append("-");   break;   // 边框
                        case 2:  canvas.Append("|");   break;   // 边框
                        case 3:  canvas.Append("+");   break;   // 边框
                        case 4:  canvas.Append("*");   break;   // 人物
                        case 5:  canvas.Append("#");   break;   // 障碍物
                        default: canvas.Append(" ");   break;
                    }
                }
                canvas.Append("\n");
            }
            return canvas;
        }

        // 输出UI界面二维数组
        public void Show_interface_array(int[,] interface_array)
        {
            for (int i = 0; i < interface_array.GetLength(0); i++)
            {
                for (int j = 0; j < interface_array.GetLength(1); j++)
                {
                    Console.Write(interface_array[i, j]);
                }
                Console.Write('\n');
            }
        }
    }
}
