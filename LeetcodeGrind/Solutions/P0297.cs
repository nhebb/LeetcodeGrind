using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 297. Serialize and Deserialize Binary Tree

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
public class BinaryTreeCodec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var vals = new List<string>();

        void Dfs(TreeNode node)
        {
            if (node == null)
            {
                vals.Add("null");
                return;
            }
            vals.Add(node.val.ToString());
            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);
        return string.Join("#", vals);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        /*  Input
            [1,2,3,null,null,4,5]
            Output
            [1,2]
            Expected
            [1,2,3,null,null,4,5]
         */
        if (string.IsNullOrEmpty(data)) return null;

        var vals = data.Split("#");
        if (vals.Length == 0 || vals[0] == "null")
            return null;

        var root = new TreeNode(int.Parse(vals[0]));
        var index = 1;

        TreeNode Dfs()
        {
            if (index >= vals.Length) return null;
            if (vals[index] == "null")
            {
                index++;
                return null;
            }

            var node = new TreeNode(int.Parse(vals[index]));
            index++;

            node.left = Dfs();
            node.right = Dfs();

            return node;
        }

        root.left = Dfs();
        root.right = Dfs();
        return root;
    }
}
