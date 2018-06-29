using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree b = new Tree();
            Random rnd = new Random();
            b.Add(b.root,30);
            b.Add(b.root,27);
            //for (int i = 0; i < 10; i++)
            //{
            //    b.Add(b.root, rnd.Next(1,100));
            //}
            b.CheckRoot();

            Console.ReadKey();
        }
    }

    
    class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }
        public void Add(Node n, int val)
        {
            if (n == null)
                n = new Node(val);
            else
            {
                if (val < n.value)
                {
                    Add(n.left, val);
                }
                if (val > n.value)
                {
                    Add(n.right, val);
                }
            }
        }
        public bool Search(Node n, int val)
        {
            if (n == null)
                return false;
            else if (n.value == val)
                return true;
            else if (n.value < val)
                return Search(n.right, val);
            else if (n.value > val)
                return Search(n.left, val);
            return false;
        }
        public void Display(Node n)
        {
            if (n != null)
                if (n.right != null)
                    Display(n.right);
                Console.WriteLine(n.value);
                if (n.left != null)
                    Display(n.left);
        }
        public void CheckRoot()
        {
            if (root != null)
            {
                Console.WriteLine("Root : " + root.value);
                if (root.left != null)
                    Console.WriteLine("Left : " + root.left.value);
                if (root.right != null)
                    Console.WriteLine("Right: " + root.right.value);
            }
            else
            {
                Console.WriteLine("Root : null");
            }
        }
    }

    class Node
    {
        public int value;
        public Node right;
        public Node left;

        public Node(int val)
        {
            value = val;
            right = null;
            left = null;
        }
    }
}
