namespace LeetcodeGrind.Solutions;

// 22. Generate Parentheses
public class P0022
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var parens = "";

        void RecurseParens(string parens, int left, int right)
        {
            if (left == right && right == n)
            {
                result.Add(parens);
                return;
            }

            if (left < n)
            {
                RecurseParens(parens + "(", left + 1, right);
            }

            if (right < left)
            {
                RecurseParens(parens + ")", left, right + 1);
            }
        }

        RecurseParens(parens, 0, 0);
        return result;
    }
}
