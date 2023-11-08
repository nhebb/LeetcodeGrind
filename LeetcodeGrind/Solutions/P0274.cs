namespace LeetcodeGrind.Solutions;

// 274. H-Index
public class P0274
{
    public int HIndex(int[] citations)
    {
        Array.Sort(citations);
        int i = 0;
        int j = citations.Length - 1;

        while (i <= j)
        {
            int m = i + (j - i) / 2;

            if (citations[m] >= citations.Length - m)
                j = m - 1;
            else
                i = m + 1;
        }

        return citations.Length - i;
    }
}
