using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This program is a way to reduce computing power in large databases.
// It stores as many numbers as possible and sorts them.
// Instead of brute-forcing all numbers in a list,
// it finds numbers by following the branches
// it can also quickly using an efficient algorithm
// sort numbers from small to large

namespace ConsoleBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
          // First we initialize the tree itself
            Tree b = new Tree();
            // We add a class so we can add random numbers
            Random rnd = new Random();
            // We add 500 as our middle and starting value
            b.Add(500,ref b.root);
            //We add a 100 random numbers between 1 and 1000
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
        // Function to add a new node to the tree
        {
          // If the node is empty, it can be added here
            if (n == null)
                n = new Node(val);
            else
            {
              // If the node is not empty, we create a new 'branch'
              // To the left is smaller, to the right is bigger
                if (val < n.value)
                    Add(val,ref n.left);
                if (val > n.value)
                    Add(val,ref n.right);
            }
        }

        public bool Search(int val,ref Node n)
        //Function to search if any number is in the list or not
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
            // recurring function, it will eventually go through all values
            // until both the left and right node are full cleared
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
        {//this is the whole GUI
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
