using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr =
            {
                {0,0,0,1,1,0,0 },
                {0,1,0,1,0,0,1 },
                {0,0,1,0,1,1,0 },
                {1,0,1,0,0,0,1 }
            };

            Wave(arr, 0, 3);
            Print(arr);
            Console.ReadKey();
        }

        static void Wave(int[,] arr, int x, int y)
        {
            bool flag = true;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int k = 2;
            arr[x, y] = k;

            while (flag)
            {
                flag = false;
                k++;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (arr[i, j] == k - 1)
                        {
                            if (i > 0 && j > 0 && arr[i - 1, j - 1] == 1)
                            {
                                arr[i - 1, j - 1] = k;
                                flag = true;
                            }

                            if (i > 0 && arr[i - 1, j] == 1)
                            {
                                arr[i - 1, j] = k;
                                flag = true;
                            }
                            if (i > 0 && j < m - 1 && arr[i - 1, j + 1] == 1)
                            {
                                arr[i - 1, j + 1] = k;
                                flag = true;
                            }
                            if (j > 0 && arr[i, j - 1] == 1)
                            {
                                arr[i, j - 1] = k;
                                flag = true;
                            }
                            if (j < m - 1 && arr[i, j + 1] == 1)
                            {
                                arr[i, j + 1] = k;
                                flag = true;
                            }
                            if (i < n - 1 && j > 0 && arr[i + 1, j - 1] == 1)
                            {
                                arr[i + 1, j - 1] = k;
                                flag = true;
                            }
                            if (i < n - 1 && arr[i + 1, j] == 1)
                            {
                                arr[i + 1, j] = k;
                                flag = true;
                            }
                            if (i < n - 1 && j < m - 1 && arr[i + 1, j + 1] == 1)
                            {
                                arr[i + 1, j + 1] = k;
                                flag = true;
                            }
                        }
                    }
                }
            }
        }

        static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}