namespace LeetcodeGrind.Solutions;

// 275. H-Index II
public class P0275
{
    public int HIndexII(int[] citations)
    {
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
