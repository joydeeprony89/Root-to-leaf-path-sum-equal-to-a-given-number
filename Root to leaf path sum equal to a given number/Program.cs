using System;
using System.Collections;
using System.Collections.Generic;

namespace Root_to_leaf_path_sum_equal_to_a_given_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.left = new Node(8);
            root.left.left = new Node(3);
            root.left.right = new Node(5);
            root.right = new Node(2);
            root.right.left = new Node(2);
            Console.WriteLine(RootToLeafSum(root, 14));
        }

        public class Node
        {
            public int val { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int val = 0)
            {
                this.val = val;
                left = right = null;
            }
        }
        static bool RootToLeftSum(Node root, int key)
        {
            if (root == null) return false;
            if (key == 0 && root.left == null && root.right == null) return true;
            return RootToLeftSum(root.left, key - root.val) || RootToLeftSum(root.right, key - root.val);
        }

        static bool RootToLeafSum(Node root, int key)
        {
            Stack<Node> stack = new Stack<Node>();
            int sum = 0;
            Node cur = root;
            Node prev = null;
            while(stack.Count > 0 || cur != null)
            {
                while (cur != null)
                {
                    sum = sum + cur.val;
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Peek();
                if (sum == key && cur.left == null && cur.right == null) return true;
                if (cur.right != null && cur.right != prev)
                {
                    cur = cur.right;
                }
                else
                {
                    prev = cur;
                    Node node = stack.Pop();
                    sum = sum - cur.val;
                    cur = null;
                }
            }
            return false;
        }
    }
}
