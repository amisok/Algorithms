using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = new string[2];
            temp = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(temp[0]);
            int m = Convert.ToInt32(temp[1]);

            temp = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(temp[0]);
            int b = Convert.ToInt32(temp[1]);

            int[,] arr = new int[n + 1, n + 1];

            for (int i = 0; i < m; i++)
            {
                temp = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(temp[0]);
                int y = Convert.ToInt32(temp[1]);
                arr[x, y] = 1;
                arr[y, x] = 1;
            }

            Console.WriteLine($"from {a} to {b}");
            Console.WriteLine("Array");
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();

            }

            int[] visited = new int[n + 1];
            int[] from_to = new int[n + 1];
            int[] way = new int[n + 1];
            int curr = 0;
            int count = 0;

            if (a != b)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(a);
                visited[a] = 1;

                while (q.Count != 0 || curr != b)
                {
                    curr = q.Dequeue();
                    for (int i = 1; i < n + 1; i++)
                    {
                        if (arr[curr, i] == 1 && visited[i] == 0)
                        {
                            q.Enqueue(i);
                            visited[i] = 1;
                            from_to[i] = curr;
                        }
                    }
                }

                if (curr == b)
                {
                    way[0] = curr;
                    while (curr != a)
                    {
                        curr = from_to[curr];
                        count++;
                        way[count] = curr;
                    }

                    Console.WriteLine($"The length of way is   {count}");
                    Console.Write("Tops:  ");
                    for (int i = n; i >= 0; i--)
                    {
                        if (way[i] != 0)
                        {
                            Console.Write(way[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error!!! The top 'b' wasn't found!!!");
                }
            }
            else
            {
                Console.WriteLine("The way is 0");
            }

            Console.ReadKey();
        }
    }
}
