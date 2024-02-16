using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1028. Recover a Tree From Preorder Traversal
public class P1028
{
    // Test case 1: traversal = "1-2--3--4-5--6--7"
    // Test case 2: traversal = "1-2--3---4-5--6---7"
    // Test case 3: traversal = "1-401--349---90--88"
    // The number of nodes in the original tree is in the range [1, 1000].
    // 1 <= Node.val <= 10^9
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var levels = new Dictionary<int, List<int>>();

        var i = traversal.IndexOf('-');
        if (i < 0)
            return new TreeNode(int.Parse(traversal));

        var root = new TreeNode(int.Parse(traversal.Substring(0, i)));


        return root;
    }
}
