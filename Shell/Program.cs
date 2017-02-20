using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 7, 8, 9, 4, 1, 5, 2, 8, 6, 7 };

            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }

        static public void Swap(int[] arr, int left, int right)
        {
            if (left != right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
        }

        static public void Sort(int[] arr)
        {
            //Сортировка вставками
            //for (int j = 1; j < arr.Length; j++)
            //{
            //    int temp = arr[j];
            //    int i = j - 1;
            //    while (i >= 0 && arr[i] > temp)
            //    {
            //        arr[i + 1] = arr[i];
            //        i = i - 1;
            //    }
            //    arr[i + 1] = temp;
            //}

            // Shell
            int d = arr.Length / 2;
            while (d > 0)
            {
                for (int i = 0; i < arr.Length - d; i++)
                {
                    int j = i;
                    while (j >= 0 && arr[j] > arr[j + d])
                    {
                        Swap(arr, j, j + d);
                        j = j - d;
                    }
                }
                d /= 2;
            }
        }
    }
}
