using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 7, 8, 9, 4, 2, 8, 6, 7 };

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
            int j = 0;
            while (j < arr.Length)
            {
                Swap(arr, j, Min(arr, j));
                j++;
            }


        }


        static public int Min(int[] arr, int j)
        {
            int min = arr[j];
            int minIndex = j;

            for (int i = j; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}
