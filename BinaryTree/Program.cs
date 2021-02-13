using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.InsertValue(30);
            binaryTree.InsertValue(28);
            binaryTree.InsertValue(15);
            binaryTree.InsertValue(4);
            binaryTree.InsertValue(7);
            binaryTree.InsertValue(13);
            binaryTree.InsertValue(17);
            binaryTree.InsertValue(9);
            binaryTree.InsertValue(12);
            binaryTree.InsertValue(14);
            binaryTree.InsertValue(16);
            binaryTree.InsertValue(18);

            //BinaryTree.Node node = binaryTree.FindNode(13);
            //binaryTree.Delete(7);

            Dictionary<int, List<int>> rows = binaryTree.GetRows();
        }
    }
}
