using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree
    {
        private Node                        m_root;
        private Dictionary<int, List<int>>  m_rows;

        public BinaryTree()
        {
            this.m_root = null;
            this.m_rows = new Dictionary<int, List<int>>();
        }

        private int populateRows(Node rootNode)
        {
            int bigger = 0;

            if (rootNode != null)
            {
                int leftDepth   = populateRows(rootNode.Left);
                int rightDepth  = populateRows(rootNode.Right);

                bigger = Math.Max(leftDepth, rightDepth) + 1;

                if (!this.m_rows.ContainsKey(bigger))
                    this.m_rows.Add(bigger, new List<int>());

                if (rootNode.Left != null)
                    this.m_rows[bigger].Add(rootNode.Left.Data);
                if (rootNode.Right != null)
                    this.m_rows[bigger].Add(rootNode.Right.Data);
            }

            return bigger;
        }

        public void InsertValue(int value)
        {
            Node newNode = new Node(value);

            if (this.m_root == null)
                this.m_root = newNode;
            else
            {
                Node currentNode    = this.m_root;
                Node previousNode   = this.m_root;

                while (true)
                {
                    if (value < currentNode.Data)
                    {
                        previousNode    = currentNode;
                        currentNode     = currentNode.Left;

                        if (currentNode == null)
                        {
                            previousNode.Left           = new Node(value);
                            previousNode.Left.Parent    = previousNode;
                            break;
                        }
                    }
                    else
                    {
                        previousNode    = currentNode;
                        currentNode     = currentNode.Right;

                        if (currentNode == null)
                        {
                            previousNode.Right          = new Node(value);
                            previousNode.Right.Parent   = previousNode;
                            break;
                        }
                    }
                }
            }
        }

        public int Min()
        {
            int     result      = 0;
            Node    currentNode = this.m_root;

            while (true)
            {
                if (currentNode.Left == null)
                {
                    result = currentNode.Data;
                    break;
                }
                else
                    currentNode = currentNode.Left;
            }

            return result;
        }

        public int Max()
        {
            int     result      = 0;
            Node    currentNode = this.m_root;

            while (true)
            {
                if (currentNode.Right == null)
                {
                    result = currentNode.Data;
                    break;
                }
                else
                    currentNode = currentNode.Right;
            }

            return result;
        }

        public Node FindNode(int value)
        {
            Node    result      = this.m_root;
            Node    currentNode = this.m_root;

            while (true)
            {
                if (value == currentNode.Data)
                {
                    result = currentNode;
                    break;
                }
                else if (value < currentNode.Data)
                    currentNode = currentNode.Left;
                else if (value > currentNode.Data)
                    currentNode = currentNode.Right;
                else if (currentNode == null)
                    break;
            }

            return result;
        }

        public void Delete(int value)
        {
            Node node = this.FindNode(value);

            // Node has no children
            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Left != null && node.Parent.Left.Data == node.Data)
                    node.Parent.Left = null;
                else
                    node.Parent.Right = null;
            }
            // Node has one child
            else if (node.Left == null || node.Right == null)
            {
                if (node.Parent.Left != null && node.Parent.Left.Data == node.Data)
                    node.Parent.Left = node.Left;
                else
                    node.Parent.Right = node.Right;
            }
            // Node has two children
            else
            {

            }
        }

        public Dictionary<int, List<int>> GetRows()
        {
            int test = this.populateRows(this.m_root);
            this.m_rows[1].Add(this.m_root.Data);

            return this.m_rows;
        }

        public class Node
        {
            public Node Parent  { get; set; }
            public Node Left    { get; set; }
            public Node Right   { get; set; }
            public int  Data    { get; set; }

            public Node(int value)
            {
                this.Data = value;
            }
        }
    }
}
