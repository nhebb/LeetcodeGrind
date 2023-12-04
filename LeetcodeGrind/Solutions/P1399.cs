namespace LeetcodeGrind.Solutions;

// 1399. Count Largest Group
public class P1399
{
    public int CountLargestGroup(int n)
    {
        var d = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++)
        {
            var sum = 0;
            var num = i;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            if (d.ContainsKey(sum))
                d[sum]++;
            else
                d[sum] = 1;
        }

        var max = d.Values.Max();
        var count = d.Values.Count(x => x == max);

        return count;
    }
}
