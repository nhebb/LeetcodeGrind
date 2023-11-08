namespace LeetcodeGrind.Solutions;

// 2432. The Employee That Worked on the Longest Task
public class P2432
{
    public int HardestWorker(int n, int[][] logs)
    {
        var res = new List<int>() { logs[0][0] };
        var longest = logs[0][1];

        for (int i = 1; i < logs.Length; i++)
        {
            var time = logs[i][1] - logs[i - 1][1];
            if (time == longest)
            {
                res.Add(logs[i][0]);
            }
            else if (time > longest)
            {
                res.Clear();
                res.Add(logs[i][0]);
                longest = time;
            }
        }

        return res.Min();
    }
}
