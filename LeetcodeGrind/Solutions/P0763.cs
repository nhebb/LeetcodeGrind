namespace LeetcodeGrind.Solutions;

// 763. Partition Labels
public class P0763
{
    public IList<int> PartitionLabels(string s)
    {
        var ans = new List<int>();
        var d = new Dictionary<char, int>();

        for (int index = 0; index < s.Length; index++)
        {
            d[s[index]] = index; // store last index only
        }

        var idx1 = 0;
        while (idx1 < s.Length)
        {
            var idx2 = d[s[idx1]];
            if (idx1 == idx2)
            {
                ans.Add(1);
                idx1++;
            }
            else
            {
                var maxIndex = idx2;
                var j = idx1 + 1;
                while (j < maxIndex)
                {
                    maxIndex = Math.Max(maxIndex, d[s[j]]);
                    j++;
                }
                ans.Add(maxIndex - idx1 + 1);
                idx1 = maxIndex + 1;
            }
        }

        return ans;
    }
}
