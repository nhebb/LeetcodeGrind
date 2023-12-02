using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 825. Friends Of Appropriate Ages
public class P0825
{
    public int NumFriendRequests(int[] ages)
    {
        // Ages range up to 120 years old
        var ageCounts = new int[121];
        for (int i = 0; i < ages.Length; i++)
        {
            ageCounts[ages[i]]++;
        }

        var count = 0;
        // Because of the 0.5 * age + 7 rule, people
        // under 15 can't send requests
        for (int i = 15; i < ageCounts.Length; i++)
        {
            var minAge = (int)(i * 0.5) + 8;
            for (int j = minAge; j <= i; j++)
            {
                // Don't count messages to self
                // in same age bracket
                var self = j == i ? 1 : 0;

                count += (ageCounts[i] - self) * ageCounts[j];
            }
        }

        return count;
    }
}
