namespace LeetcodeGrind.Solutions;

// 2244. Minimum Rounds to Complete All Tasks
public class P2244
{
    public int MinimumRounds(int[] tasks)
    {
        var difficultyCounts = new Dictionary<int, int>();
        foreach (var task in tasks)
        {
            if (difficultyCounts.TryGetValue(task, out int val))
                difficultyCounts[task] = val + 1;
            else
                difficultyCounts[task] = 1;
        }

        var rounds = 0;
        foreach (var kvp in difficultyCounts)
        {
            if (kvp.Value == 1)
                return -1;

            var count = kvp.Value;
            while (count > 0)
            {
                if (count == 4)
                {
                    rounds += 2;
                    count = 0;
                }
                else if (count <= 3)
                {
                    rounds++;
                    count = 0;
                }
                else
                {
                    count -= 3;
                    rounds++;
                }
            }
        }

        return rounds;
    }
}
