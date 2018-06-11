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
            b.AddNode(30);
            b.AddNode(27);
            //for (int i = 0; i < 10; i++)
            //{
            //    b.AddNode(rnd.Next(1,100));
            //}



            b.CheckRoot();
            Console.ReadLine();
        }
    }

    class Tree
    {
        public Node root;
        private int num;

        public Tree()
        {
            root = null;
        }
        public void AddNode(int aval)
        {
            if (root == null)
                root = new Node(aval);
            else
                root.AddValue(root, aval);
            num++;
        }
        public bool Search(Node node, int sval)
        {
            return node.SearchValue(root, sval);
        }
        public void Display()
        {
            if (root != null)
                root.Display(root);
        }
        public void CheckRoot()
        {
            if (root != null)
                Console.WriteLine("Root : " + root.value);
            if (root.left != null)
                Console.WriteLine("Left : " + root.left.value);
            if (root.right != null)
                Console.WriteLine("Right: " + root.right.value);
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
        public Node AddValue(Node n, int val)
        {
            if (n == null)
                return new Node(val);
            else if (n.value < val)
                return AddValue(n.right, val);
            else
                return AddValue(n.left, val);
        }
        public bool SearchValue(Node n, int val)
        {
            if (n == null)
                return false;
            if (n.value == val)
                return true;
            if (n.value < val)
                return SearchValue(n.right, val);
            if (n.value > val)
                return SearchValue(n.left, val);
            return false;
        }
        public void Display(Node n)
        {
            if (n.right != null)
                n.Display(n.right);
            Console.WriteLine(n.value);
            if (n.left != null)
                n.Display(n.left);
        }
    }
}
