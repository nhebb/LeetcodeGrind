using LeetcodeGrind.LinkedLists;
using System;
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

            DFS(node.right);
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


    // 508. Most Frequent Subtree Sum
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        var d = new Dictionary<int, int>();
        var freq = new List<int>();
        var maxFreq = 0;

        int Dfs(TreeNode node)
        {
            if (node == null)
                return 0;

            var sum = node.val + Dfs(node.left) + Dfs(node.right);

            if (d.TryGetValue(sum, out var val))
                d[sum] = val + 1;
            else
                d[sum] = 1;

            if (d[sum] == maxFreq)
            {
                freq.Add(sum);
            }
            else if (d[sum] > maxFreq)
            {
                maxFreq = d[sum];
                freq.Clear();
                freq.Add(sum);
            }

            return sum;
        }

        Dfs(root);

        return freq.ToArray();
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


    // 111. Minimum Depth of Binary Tree
    public int MinDepth(TreeNode root)
    {
        if (root == null) return 0;
        var minDepth = int.MaxValue;

        void Dfs(TreeNode node, int depth)
        {
            if (node == null) return;

            if (node.left == null && node.right == null)
            {
                minDepth = Math.Min(minDepth, depth);
                return;
            }
            Dfs(node.left, depth + 1);
            Dfs(node.right, depth + 1);
        }

        Dfs(root, 1);

        return minDepth;
    }


    // 108. Convert Sorted Array to Binary Search Tree
    public TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null;

        TreeNode Dfs(int idx1, int idx2)
        {
            if (idx2 < idx1) return null;

            var mid = idx1 + (idx2 - idx1) / 2;

            var node = new TreeNode(nums[mid]);
            node.left = Dfs(idx1, mid - 1);
            node.right = Dfs(mid + 1, idx2);

            return node;
        }

        var root = Dfs(0, nums.Length - 1);

        return root;
    }


    // 257. Binary Tree Paths
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();

        void BackTrack(TreeNode node, List<int> vals)
        {
            vals.Add(node.val);

            if (node.left != null)
                BackTrack(node.left, vals);

            if (node.right != null)
                BackTrack(node.right, vals);

            if (node.left == null && node.right == null)
                result.Add(string.Join("->", vals));

            vals.RemoveAt(vals.Count - 1);
        }

        BackTrack(root, new List<int>());

        return result;
    }



    // 2120. Execution of All Suffix Instructions Staying in a Grid
    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        var result = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            var r = startPos[0];
            var c = startPos[1];
            var moves = 0;
            for (int j = i; j < s.Length; j++)
            {
                var dir = s[j];
                if (dir == 'L')
                    c--;
                else if (dir == 'R')
                    c++;
                else if (dir == 'U')
                    r--;
                else
                    r++;

                if (c >= 0 && c < n && r >= 0 && r < n)
                    moves++;
                else
                    break;

            }
            result[i] = moves;
        }
        return result;
    }


    // 1022. Sum of Root To Leaf Binary Numbers
    public int SumRootToLeaf(TreeNode root)
    {
        if (root == null) return 0;

        var sum = 0;

        void Dfs(TreeNode node, int val)
        {
            var curVal = node.val;
            val = (val << 1) | curVal;

            if (node.left == null && node.right == null)
            {
                sum += val;
                return;
            }

            if (node.left != null)
                Dfs(node.left, val);

            if (node.right != null)
                Dfs(node.right, val);
        }

        Dfs(root, 0);

        return sum;
    }


    // 617. Merge Two Binary Trees
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
            return root2;

        if (root2 == null)
            return root1;

        void Dfs(TreeNode node1, TreeNode node2)
        {
            node1.val += node2.val;

            if (node1.left == null && node2.left != null)
                node1.left = node2.left;
            else if (node2.left != null)
                Dfs(node1.left, node2.left);

            if (node1.right == null && node2.right != null)
                node1.right = node2.right;
            else if (node2.right != null)
                Dfs(node1.right, node2.right);
        }

        Dfs(root1, root2);

        return root1;
    }


    // 1305. All Elements in Two Binary Search Trees
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        void Dfs(TreeNode node, List<int> list)
        {
            if (node.left != null)
                Dfs(node.left, list);
            list.Add(node.val);
            if (node.right != null)
                Dfs(node.right, list);
        }

        var list1 = new List<int>();
        var list2 = new List<int>();

        if (root1 != null)
            Dfs(root1, list1);
        if (root2 != null)
            Dfs(root2, list2);

        var ans = new List<int>(list1.Count + list2.Count);

        int i = 0;
        int j = 0;
        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] < list2[j])
            {
                ans.Add(list1[i]);
                i++;
            }
            else
            {
                ans.Add(list2[j]);
                j++;
            }
        }

        while (i < list1.Count)
        {
            ans.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            ans.Add(list2[j]);
            j++;
        }

        return ans;
    }


    // 1382. Balance a Binary Search Tree
    public TreeNode BalanceBST(TreeNode root)
    {
        var nodeList = new List<TreeNode>();
        BuildNodeList(root);

        foreach (var node in nodeList)
        {
            node.left = null;
            node.right = null;
        }

        void BuildNodeList(TreeNode node)
        {
            if (node == null) return;

            BuildNodeList(node.left);
            nodeList.Add(node);
            BuildNodeList(node.right);
        }

        TreeNode BuildBst(int idx1, int idx2)
        {
            if (idx2 < idx1) return null;

            var mid = idx1 + (idx2 - idx1) / 2;

            var node = nodeList[mid];
            node.left = BuildBst(idx1, mid - 1);
            node.right = BuildBst(mid + 1, idx2);

            return node;
        }

        return BuildBst(0, nodeList.Count - 1);
    }


    // 404. Sum of Left Leaves
    public int SumOfLeftLeaves(TreeNode root)
    {
        var sum = 0;

        void Dfs(TreeNode node, bool isLeft)
        {
            if (node == null) return;

            if (isLeft && node.left == null && node.right == null)
            {
                sum += node.val;
                return;
            }

            Dfs(node.left, true);
            Dfs(node.right, false);
        }

        Dfs(root, false);

        return sum;
    }


    // 109. Convert Sorted List to Binary Search Tree
    public TreeNode SortedListToBST(ListNode head)
    {
        if (head == null) return null;

        var nums = new List<int>();
        while (head != null)
        {
            nums.Add(head.val);
            head = head.next;
        }

        TreeNode CreateTree(int low, int high)
        {
            if (high < low)
                return null;

            var mid = low + (high - low) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = CreateTree(low, mid - 1);
            node.right = CreateTree(mid + 1, high);
            return node;
        }

        return CreateTree(0, nums.Count - 1);
    }


    // 129. Sum Root to Leaf Numbers
    public int SumNumbers(TreeNode root)
    {
        var sb = new StringBuilder();
        var sum = 0;

        void Dfs(TreeNode node)
        {
            sb.Append(node.val);
            if (node.left == null && node.right == null)
            {
                sum += int.Parse(sb.ToString());
            }
            if (node.left != null) Dfs(node.left);
            if (node.right != null) Dfs(node.right);

            sb.Remove(sb.Length - 1, 1);
        }
        Dfs(root);
        return sum;
    }


    // 513. Find Bottom Left Tree Value
    public int FindBottomLeftValue(TreeNode root)
    {
        var maxDepth = 0;
        var minCol = 0;
        var result = root.val;

        void Dfs(TreeNode node, int depth, int col)
        {
            if (depth > maxDepth
                || (depth == maxDepth && col < minCol))
            {
                maxDepth = depth;
                minCol = col;
                result = node.val;
            }

            if (node.left != null)
                Dfs(node.left, depth + 1, col - 1);

            if (node.right != null)
                Dfs(node.right, depth + 1, col + 1);
        }

        Dfs(root, 0, 0);

        return result;
    }
}
