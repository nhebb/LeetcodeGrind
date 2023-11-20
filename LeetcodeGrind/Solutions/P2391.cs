namespace LeetcodeGrind.Solutions;

// 2391. Minimum Amount of Time to Collect Garbage
public class P2391
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var count = garbage[0].Count(x => x == 'G' || x == 'P' | x == 'M');

        for (int i = 1; i < garbage.Length; i++)
        {
            count += garbage[i].Count(x => x == 'G' || x == 'P' | x == 'M')
                + 3 * travel[i - 1]; ;
        }

        for (int i = garbage.Length - 1; i >= 1; i--)
        {
            if (!garbage[i].Contains('G'))
                count -= travel[i - 1];
            else
                break;
        }

        for (int i = garbage.Length - 1; i >= 1; i--)
        {
            if (!garbage[i].Contains('P'))
                count -= travel[i - 1];
            else
                break;
        }

        for (int i = garbage.Length - 1; i >= 1; i--)
        {
            if (!garbage[i].Contains('M'))
                count -= travel[i - 1];
            else
                break;
        }

        return count;
    }
}
