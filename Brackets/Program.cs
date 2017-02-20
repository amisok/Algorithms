using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Node
    {
        public char value;
        public Node next;
        public Node(char value, Node next)
        {
            this.value = value;
            this.next = next;
        }
    }

    class Stack
    {
        public Node top;

        public void Push(char value)
        {
            top = new Node(value, top);
        }

        public bool Pop(out char value)
        {
            if (top == null)
            {
                value = '\0';
                return false;
            }
            value = top.value;
            top = top.next;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char value;
            char[] enter = { '(', '(', ')', ')', '(' };

            Stack stack = new Stack();

            for (int i = 0; i < enter.Length; i++)
            {
                if (enter[i] == '(')
                {
                    stack.Push(enter[i]);
                }
                else if (enter[i] == ')')
                {
                    if (!stack.Pop(out value))
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Error!!!");
                }
            }

            if (!stack.Pop(out value))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            Console.ReadKey();
        }
    }
}
