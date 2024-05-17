using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2331. Evaluate Boolean Binary Tree
public class P2331
{
    public bool EvaluateTree(TreeNode root)
    {
        if (root.val == 3)
        {
            return EvaluateTree(root.left) && EvaluateTree(root.right);
        }
        else if (root.val == 2)
        {
            return EvaluateTree(root.left) || EvaluateTree(root.right);
        }

        return root.val == 1;
    }
}
