namespace LeetcodeGrind.Solutions;

// 621. Task Scheduler
// TODO: Finish this.
public class P0621
{
    public int LeastInterval(char[] tasks, int n)
    {
        var d = new Dictionary<char, int>();
        var arr = new int[26];

        foreach (var c in tasks)
            arr[c - 'A']++;

        // Approach:
        // create an array of task counts

        return 0;

    }
}
