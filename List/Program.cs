using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListNode
    {
        public int value;

        public ListNode(int value)
        {
            this.value = value;
        }

        public ListNode next;
        public ListNode previous;
    }

    class List
    {
        public ListNode head;
        public ListNode tail;
        public int count;

        public void AddAfter(int after, int data)
        {
            ListNode current = head;
            while (current != null && current.value != after)
            {
                current = current.next;
            }

            if (current == null)
                return;

            ListNode node = new ListNode(data);
            node.previous = current;
            node.next = current.next;
            current.next = node;
            if (node.next != null)
            {
                node.next.previous = node;
            }
        }

        public override string ToString()
        {
            string str = "";
            ListNode current = head;
            while (current != null)
            {
                str += current.value.ToString();
                str += ",";
                current = current.next;
            }
            return str;
        }

        public void Add(int data)
        {
            ListNode node = new ListNode(data);
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                tail.next = node;
                node.previous = tail;
                tail = node;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.AddAfter(3, 6);
            Console.WriteLine("list: {0}", list);
            Console.ReadKey();
        }
    }
}
