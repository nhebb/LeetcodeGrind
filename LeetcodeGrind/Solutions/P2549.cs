namespace LeetcodeGrind.Solutions;

// 2549. Count Distinct Numbers on Board
public class P2549
{
    public int DistinctIntegers(int n)
    {
        var board = new HashSet<int>() { n };
        var cache = new HashSet<int>();

        for (int i = 2; i <= n; i++)
        {
            foreach (var num in board)
            {
                if (num % i == 1)
                    cache.Add(num);
            }
            foreach (var num in cache)
            {
                board.Add(num);
            }
            cache.Clear();
        }

        return board.Count;
    }
}
