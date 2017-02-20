using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree avl = new Tree();
            avl.Add(5);
            avl.Add(3);
            avl.Add(4);
            avl.Add(7);
            avl.Add(8);
            avl.Add(6);
            avl.Add(11);
            avl.Remove(5);
            Console.ReadKey();
        }
    }

    class Node
    {
        public int data;
        public int height;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
            height = 1;
        }
    }

    class Tree
    {
        Node head = null;

        public Node Insert(Node node, int data)
        {
            if (node != null)
            {
                if (data < node.data)
                    node.left = Insert(node.left, data);
                else if (data >= node.data)
                    node.right = Insert(node.right, data);
            }
            else return new Node(data);
            return Balance(node);
        }

        public void Add(int data)
        {
            head = Insert(head, data);
        }

        public void Remove(int data)
        {
            head = Delete(head, data);
        }

        public Node Delete(Node node, int data)
        {
            if (node == null)
                return null;

            if (data < node.data)
                node.left = Delete(node.left, data);
            else if (data > node.data)
                node.right = Delete(node.right, data);
            else
            {
                Node l = node.left;
                Node r = node.right;

                if (r == null)
                    return l;

                Node min = FindMin(r);
                min.right = RemoveMin(r);
                min.left = l;
                return Balance(min);
            }
            return Balance(node);
        }

        public Node FindMin(Node node)
        {
            Node curr = node;
            while (curr.left != null)
                curr = curr.left;
            return curr;
        }

        public Node RemoveMin(Node node)
        {
            if (node.left == null)
                return node.right;

            node.left = RemoveMin(node.left);
            return Balance(node);
        }

        public Node Balance(Node node)
        {
            FixHeight(node);

            if (BalFactor(node) == 2)
            {
                if (BalFactor(node.right) < 0)
                    node.right = RightRotation(node.right);
                return LeftRotation(node);
            }

            if (BalFactor(node) == -2)
            {
                if (BalFactor(node.left) > 0)
                    node.left = LeftRotation(node.left);
                return RightRotation(node);
            }
            return node;
        }

        public int Height(Node node)
        {
            if (node != null)
                return node.height;
            else
                return 0;
        }


        public int BalFactor(Node node)
        {
            return Height(node.right) - Height(node.left);
        }

        public void FixHeight(Node node)
        {
            int hl = Height(node.left);
            int hr = Height(node.right);

            node.height = (hl > hr ? hl : hr) + 1;
        }

        public Node RightRotation(Node node)
        {
            Node temp = node.left;
            node.left = temp.right;
            temp.right = node;
            FixHeight(node);
            FixHeight(temp);
            return temp;
        }

        public Node LeftRotation(Node node)
        {
            Node temp = node.right;
            node.right = temp.left;
            temp.left = node;
            FixHeight(node);
            FixHeight(temp);
            return temp;
        }
    }
}
