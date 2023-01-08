using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.Trees.NAry;


public partial class Solution
{
    // 590. N-ary Tree Postorder Traversal
    public IList<int> Postorder(NAryNode root)
    {
        var res = new List<int>();

        void Dfs(NAryNode node)
        {
            if (node == null) return;

            if (node.children.Count > 0)
                foreach (var child in node.children)
                    Dfs(child);

            res.Add(node.val);
        }
        Dfs(root);
        return res;
    }

    // 559. Maximum Depth of N-ary Tree

    public int MaxDepth(NAryNode root)
    {
        if (root == null) return 0;

        int Dfs(NAryNode node)
        {
            if (node == null) return 0;
            var max = 0;
            foreach (var child in node.children)
            {
                max = Math.Max(max, Dfs(child));
            }
            return 1 + max;
        }

        return Dfs(root);
    }
}
