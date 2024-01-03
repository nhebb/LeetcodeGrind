namespace LeetcodeGrind.Solutions;

// 216. Combination Sum III
public class P0216
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var ans = new List<IList<int>>();
        var hs = new HashSet<string>();

        void AddNext(List<int> curList, int i, int count, int sum)
        {
            if (count == 0 && sum == n)
            {
                var s = string.Join(",", curList);
                if (hs.Add(s))
                {
                    ans.Add(new List<int>(curList));
                    return;
                }
            }

            for (int j = i; j <= 9; j++)
            {
                sum += j;
                if (sum > n)
                {
                    break;
                }

                curList.Add(j);
                AddNext(curList, j + 1, count - 1, sum);
                curList.RemoveAt(curList.Count - 1);
                sum -= j;
            }
        }

        AddNext(new List<int>(), 1, k, 0);

        return ans;
    }
}
