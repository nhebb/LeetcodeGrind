namespace LeetcodeGrind.Solutions;

// 241. Different Ways to Add Parentheses
public class P0241
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        // Dictionary to store results for subexpressions
        var dp = new Dictionary<string, List<int>>();
        var operators = new HashSet<int> { '*', '+', '-' };

        // Evaluate sub-expressions
        List<int> EvaluateExpression(string expr)
        {
            // Check memoized results
            if (dp.TryGetValue(expr, out List<int>? value))
            {
                return value;
            }

            var result = new List<int>();
            var isNumber = true;

            // Find operators
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (operators.Contains(c))
                {
                    isNumber = false;

                    // Split expression at operator
                    var left = expr.Substring(0, i);
                    var right = expr.Substring(i + 1);

                    // Evaluate the left and right parts
                    var leftResults = EvaluateExpression(left);
                    var rightResults = EvaluateExpression(right);

                    // Combine the results using the current operator
                    foreach (int leftVal in leftResults)
                    {
                        foreach (int rightVal in rightResults)
                        {
                            if (c == '+')
                                result.Add(leftVal + rightVal);
                            else if (c == '-')
                                result.Add(leftVal - rightVal);
                            else if (c == '*')
                                result.Add(leftVal * rightVal);
                        }
                    }
                }
            }

            // If no operator found, expression is a number
            if (isNumber)
            {
                result.Add(int.Parse(expr));
            }

            // Memoize result
            dp[expr] = result;
            return result;
        }

        return EvaluateExpression(expression);
    }
}

