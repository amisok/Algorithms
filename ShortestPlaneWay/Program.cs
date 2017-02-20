using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPlaneWay
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr =
            {
                {0, 5, 0, 6, 0, 50},
                {0, 0, 7, 0, 0, 0},
                {0, 0, 0, 0, 0, 10},
                {0, 0, 4, 0, 10, 0},
                {0, 0, 0, 0, 0, 8},
                {0, 0, 0, 0, 0, 0}
            };

            Gragh gragh = new Gragh(arr);
            gragh.ShortestWay(0, 2);
            Console.ReadKey();
        }
    }

    class Gragh
    {
        int[,] gragh;
        int n, curr;

        public Gragh(int[,] gragh)
        {
            this.gragh = gragh;
            n = gragh.GetLength(0);
        }

        public void ShortestWay(int from, int to)
        {
            bool[] visited = new bool[n];
            int[] cost = new int[n];

            for (int i = 0; i < n; i++)
            {
                cost[i] = int.MaxValue;
            }

            curr = from;
            cost[from] = 0;

            while (curr != to)
            {
                int min = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (cost[i] < min && !visited[i])
                    {
                        min = cost[i];
                        curr = i;
                    }
                }

                visited[curr] = true;
                for (int j = 0; j < n; j++)
                {
                    if (gragh[curr, j] > 0 && !visited[j])
                    {
                        int temp = cost[curr] + gragh[curr, j];
                        if (cost[j] > temp)
                        {
                            cost[j] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("The way from {0} to {1} costs {2}", from, to, cost[to]);
        }
    }
}
