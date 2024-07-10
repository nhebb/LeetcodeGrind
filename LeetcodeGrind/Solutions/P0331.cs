namespace LeetcodeGrind.Solutions;

// 331. Verify Preorder Serialization of a Binary Tree
public class P0331
{
    public bool IsValidSerialization(string preorder)
    {
        var values = preorder.Split(",");
        var stack = new Stack<string>();

        foreach (string value in values)
        {
            stack.Push(value);

            while (stack.Count >= 3)
            {
                string right = stack.Pop();
                string left = stack.Pop();
                string root = stack.Pop();

                if (right == "#" && left == "#")
                {
                    if (root == "#")
                    {
                        return false;
                    }
                    stack.Push("#");
                }
                else
                {
                    stack.Push(root);
                    stack.Push(left);
                    stack.Push(right);
                    break;
                }
            }
        }

        return stack.Count == 1 && stack.Peek() == "#";
    }
}
