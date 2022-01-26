using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class BinaryTree_DFS
    {
        /// <summary>
        /// **** Swap BST nodes https://www.hackerrank.com/challenges/swap-nodes-algo/problem?h_l=interview&isFullScreen=false&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
        /// We define depth of a node as follows:
        ///        The root node is at depth 1.
        ///If the depth of the parent node is d, then the depth of current node will be d+1.
        ///Given a tree and an integer, k, in one operation, we need to swap the subtrees 
        ///of all the nodes at each depth h, where h ∈ [k, 2k, 3k,...]. 
        ///In other words, if h is a multiple of k, swap the left and right subtrees of that level.
        ///You are given a tree of n nodes where nodes are indexed from [1..n] and 
        ///it is rooted at 1. You have to perform t swap operations on it, and 
        ///after each swap operation print the in-order traversal of the current state of the tree.
        ///
        /// Test:  BinaryTree_DFS.swapNodes(new List<List<int>> { new List<int> { 2, 3 }, new List<int> { -1, -1 }, new List<int> { -1, -1 } }, new List<int> { 1, 1 });
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
        {
            List<List<int>> output = new List<List<int>>();

            Node[] nodes = new Node[indexes.Count + 1];
            //create all nodes and added them into an array
            for (int i = 1; i <= indexes.Count; i++) nodes[i] = new Node(i);

            //make the tree by picking the referance from array
            int parent = 1;
            foreach (List<int> arr in indexes)
            {
                if (arr[0] != -1) nodes[parent].left = nodes[arr[0]];
                if (arr[1] != -1) nodes[parent].right = nodes[arr[1]];
                parent++;
                Console.WriteLine(" ");
            }

            //accumulate the nodes in each depth at a time
            Dictionary<int, List<Node>> depths = new Dictionary<int, List<Node>>();
            DepthNodes(nodes[1], 1, depths);

            //now exchange the depth nodes
            foreach (int d in queries)
            {
                for (int i = d; i <= depths.Count; i += d)
                {
                    //do swap between left and right child of same depth nodes
                    foreach (Node node in depths[i])
                    {
                        Node tmp = node.left;
                        node.left = node.right;
                        node.right = tmp;
                    }
                }
                //now accumulate the inOrder travel data
                List<int> travelData = new List<int>();
                inOrderTravel(nodes[1], travelData);
                output.Add(travelData);
            }

            return output;
        }

        public static void DepthNodes(Node node, int d, Dictionary<int, List<Node>> depths)
        {
            if (node == null) return;
            if (depths.ContainsKey(d)) depths[d].Add(node);
            else
            {
                depths[d] = new List<Node>();
                depths[d].Add(node);
            }
            DepthNodes(node.left, d + 1, depths);
            DepthNodes(node.right, d + 1, depths);
        }

        public static void inOrderTravel(Node temp, List<int> travelData)
        {
            if (temp == null) return;
            inOrderTravel(temp.left, travelData);
            travelData.Add(temp.data);
            inOrderTravel(temp.right, travelData);
        }

        public class Node
        {
            public int data;
            public Node left, right;

            public Node(int d)
            {
                this.data = d;
                this.left = null;
                this.right = null;
            }
        }
    }
}
