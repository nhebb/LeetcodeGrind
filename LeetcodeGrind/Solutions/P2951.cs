namespace LeetcodeGrind.Solutions;

// 2951. Find the Peaks
public class P2951
{
    public IList<int> FindPeaks(int[] mountain)
    {
        var result = new List<int>();

        for (int i = 1; i < mountain.Length - 1; i++)
        {
            if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1])
            {
                result.Add(i);
            }
        }

        return result;
    }
}
