﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.Trees;

public class Trees
{
    // 94. Binary Tree Inorder Traversal
    public IList<int> InorderTraversal(TreeNode root)
    {
        var list = new List<int>();

        void DFS(TreeNode node)
        {
            if (node == null) return;

            DFS(node.left);
            list.Add(node.val);
            DFS(node.right);
        }

        DFS(root);
        return list;
    }


    // 144. Binary Tree Preorder Traversal
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var preorder = new List<int> { };
        void Dfs(TreeNode node)
        {
            if (node == null) return;
            preorder.Add(node.val);
            Dfs(node.left);
            Dfs(node.right);
        }
        Dfs(root);
        return preorder;
    }


    // 145. Binary Tree Postorder Traversal
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var postorder = new List<int>() { };
        void Dfs(TreeNode node)
        {
            if (node == null) return;
            Dfs(node.left);
            Dfs(node.right);
            postorder.Add(node.val);
        }
        Dfs(root);
        return postorder;
    }


    // 226. Invert Binary Tree
    public TreeNode InvertTree(TreeNode root)
    {
        void FlipNodes(TreeNode node)
        {
            if (node == null) { return; }

            (node.left, node.right) = (node.right, node.left);

            FlipNodes(node.left);
            FlipNodes(node.right);
        }

        FlipNodes(root);
        return root;
    }


    // 104. Maximum Depth of Binary Tree
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }


    // 543. Diameter of Binary Tree
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var maxPath = 0;

        int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            var left = Dfs(node.left);
            var right = Dfs(node.right);
            var path = left + right;
            maxPath = Math.Max(maxPath, path);
            return 1 + Math.Max(left, right);
        }

        Dfs(root);
        return maxPath;
    }


    // 110. Balanced Binary Tree
    public bool IsBalanced(TreeNode root)
    {
        bool balanced = true;

        int DepthDFS(TreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = DepthDFS(node.left);
            int rightDepth = DepthDFS(node.right);

            if (Math.Abs(leftDepth - rightDepth) > 1)
                balanced = false;

            return 1 + Math.Max(leftDepth, rightDepth);
        }

        _ = DepthDFS(root);
        return balanced;
    }

    // 100. Same Tree
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        if (p.val != q.val) return false;

        return IsSameTree(p.left, q.left)
            && IsSameTree(p.right, q.right);
    }


    // 572. Subtree of Another Tree
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null) return false;

        bool DfsMatch(TreeNode r, TreeNode s)
        {
            if (r == null && s == null) return true;

            if (r == null || s == null || r.val != s.val)
                return false;

            return DfsMatch(r.left, s.left)
                && DfsMatch(r.right, s.right);
        }

        if (DfsMatch(root, subRoot))
            return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }


    // TODO: Finish this
    // 108. Convert Sorted Array to Binary Search Tree
    //public TreeNode SortedArrayToBST(int[] nums)
    //{

    //}


    // 235. Lowest Common Ancestor of a Binary Search Tree
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        // if p or q == root.val, then root is LCA
        if (p.val == root.val || q.val == root.val)
            return root;

        // if p and q fork paths, root is LCA
        if ((p.val < root.val && q.val > root.val) ||
            (p.val > root.val && q.val < root.val))
            return root;

        // if p & q < root, recurse left
        if (p.val < root.val && q.val < root.val)
            return LowestCommonAncestor(root.left, p, q);

        // only remaining option is to go right
        return LowestCommonAncestor(root.right, p, q);
    }


    // 102. Binary Tree Level Order Traversal
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var lists = new List<IList<int>>();
        if (root == null) { return lists; }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                list.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            lists.Add(list);
        }
        return lists;
    }


    // 105. Construct Binary Tree from Preorder and Inorder Traversal
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 1) return new TreeNode(preorder[0]);
        var preIndex = 0;

        // minIndex and maxIndex are for the inorder array
        TreeNode Dfs(int minIndex, int maxIndex)
        {
            if (preIndex >= preorder.Length || minIndex > maxIndex) return null;

            var val = preorder[preIndex];
            preIndex++;

            var node = new TreeNode(val);
            var mid = Array.IndexOf(inorder, val);

            node.left = Dfs(minIndex, mid - 1);
            node.right = Dfs(mid + 1, maxIndex);

            return node;
        }
        var root = Dfs(0, inorder.Length - 1);
        return root;
    }



    // 1448. Count Good Nodes in Binary Tree
    public int GoodNodes(TreeNode root)
    {
        var good = 1;

        void Dfs(TreeNode node, int maxVal)
        {
            if (node == null) return;
            if (node.val >= maxVal)
            {
                good++;
                maxVal = node.val;
            }
            Dfs(node.left, maxVal);
            Dfs(node.right, maxVal);
        }

        Dfs(root.left, root.val);
        Dfs(root.right, root.val);

        return good;
    }
}