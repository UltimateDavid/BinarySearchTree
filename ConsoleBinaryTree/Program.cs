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
            b.Add(500,ref b.root);
            for (int i = 0; i < 100; i++)
            {
                b.Add(rnd.Next(1,1000), ref b.root);
            }

            b.Display(b.root);
            b.Input();
        }
    }

    class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public void Add(int val, ref Node n)
        {
            if (n == null)
                n = new Node(val);
            else
            {
                if (val < n.value)
                    Add(val,ref n.left);
                if (val > n.value)
                    Add(val,ref n.right);
            }
        }
        public bool Search(int val,ref Node n)
        {
            if (n == null)
                return false;
            else if (n.value == val)
                return true;
            else if (n.value < val)
                return Search(val, ref n.right);
            else if (n.value > val)
                return Search(val, ref n.left);
            return false;
        }
        public void Display(Node n)
        {
            if (n != null)
                if (n.left != null)
                    Display(n.left);
            Console.Write(n.value + ", ");
            if (n.right != null)
                Display(n.right);
        }
        public void CheckRoot()
        {
            if (root != null)
            {
                Console.WriteLine("Root: " + root.value);
                if (root.left != null)
                    Console.WriteLine("Left: " + root.left.value);
                if (root.right != null)
                    Console.WriteLine("Right: " + root.right.value);
            }
            else
                Console.WriteLine("Root: null");
        }
        public void Input()
        {
            while (true)
            {
                Console.WriteLine("\r\nChoose 1-Search, 2-Display, 3-Add or 4-Exit");
                ConsoleKeyInfo key = Console.ReadKey();
                string s = key.KeyChar.ToString();
                if (String.Equals(s, "1"))
                {
                    Console.WriteLine("\r\nInput:");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int num))
                    {
                        if (Search(num, ref root))
                            Console.WriteLine("Found");
                        else
                            Console.WriteLine("Not found");
                    }
                }
                else if (String.Equals(s, "2"))
                {
                    Console.WriteLine("\r\nTree:");
                    Display(root);
                }
                else if (String.Equals(s, "3"))
                {
                    Console.WriteLine("\r\nInput:");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int num))
                        Add(val: num, n: ref root);
                }
                else if (String.Equals(s, "4"))
                    break;
                else
                    Console.WriteLine("Wrong input!");
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
