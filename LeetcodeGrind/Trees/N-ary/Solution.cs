using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Trees.N_ary;


public class Solution
{
    // Note: Changed class name from Node to NAryNode to
    // avoid naming conflicts with other specialized node classes
    public class NAryNode
    {
        public int val;
        public IList<NAryNode> children;

        public NAryNode() { }

        public NAryNode(int val) => this.val = val;

        public NAryNode(int val, IList<NAryNode> children)
        {
            this.val = val;
            this.children = children;
        }
    }


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
