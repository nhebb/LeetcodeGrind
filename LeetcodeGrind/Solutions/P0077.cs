namespace LeetcodeGrind.Solutions;

// 77. Combinations
public class P0077
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void Backtrack(int i)
        {
            for (int j = i; j <= n - k + combo.Count + 1; j++)
            {
                combo.Add(j);

                if (combo.Count == k)
                    ans.Add(new List<int>(combo));
                else if (j < n - k + combo.Count + 1)
                    Backtrack(j + 1);

                combo.RemoveAt(combo.Count - 1);
            }
        }

        Backtrack(1);

        return ans;
    }


    // Another solution
    public IList<IList<int>> Combine2(int n, int k)
    {
        var iterations = 0;
        var result = new List<IList<int>>();

        void FindCombinations(IList<int> acc)
        {
            if (acc.Count == k)
            {
                result.Add(new List<int>(acc));
                return;
            }

            var lastNum = acc[^1];
            for (var num = lastNum + 1; num <= n - (k - acc.Count - 1); num++)
            {
                acc.Add(num);
                iterations++;
                FindCombinations(acc);
                acc.RemoveAt(acc.Count - 1);
            }
        }

        for (var startNum = 1; startNum <= n - k + 1; startNum++)
        {
            FindCombinations(new List<int> { startNum });
        }

        //Console.WriteLine($"Combine2: {iterations}");
        return result;

    }

}
