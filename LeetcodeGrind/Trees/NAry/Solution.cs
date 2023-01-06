using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
