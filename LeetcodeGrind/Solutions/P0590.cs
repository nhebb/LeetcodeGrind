namespace LeetcodeGrind.NAryTree;

// 590. N-ary Tree Postorder Traversal
public class P0590
{
    public IList<int> Postorder(Node root)
    {
        var res = new List<int>();

        void Dfs(Node node)
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

// N-ary Node definition
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int val) => this.val = val;

    public Node(int val, IList<Node> children)
    {
        this.val = val;
        this.children = children;
    }
}