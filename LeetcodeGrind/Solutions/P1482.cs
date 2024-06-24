namespace LeetcodeGrind.Solutions;

// 1482. Minimum Number of Days to Make m Bouquets
public class P1482
{
    public int MinDays(int[] bloomDay, int m, int k)
    {
        if (bloomDay.Length / k < m)
        {
            return -1; // Not enough flowers
        }

        // We're doing a 'Binary Search on Solution', so first
        // we're setting up the left and right boundaries for the
        // optimal number of days ...
        var left = int.MaxValue;
        var right = int.MinValue;
        foreach (var day in bloomDay)
        {
            left = Math.Min(left, day);
            right = Math.Max(right, day);
        }

        // ... then we have a local function to check if it's
        // possible to create at least 'm' bouquets on that day.
        bool CanMakeBouquets(int targetDay)
        {
            var count = 0;
            var bouquets = 0;

            // Unfortunately, we still need to slough through all
            // the days to check the possible bouquet count.
            for (int i = 0; i < bloomDay.Length; i++)
            {
                if (bloomDay[i] <= targetDay)
                {
                    count++; // Flower has bloomed
                }
                else
                {
                    // Add any k groups to bouquet count and reset
                    // counter for non-adjacent days.
                    bouquets += count / k;
                    count = 0;
                }
            }

            // Add any remaining flowers to the bouquet count.
            bouquets += count / k;

            return bouquets >= m;
        }

        // Perform the binary search to find the minimum number
        // of days (minDay).
        var minDay = right;
        while (left <= right)
        {
            var currentDay = left + (right - left) / 2;

            if (CanMakeBouquets(currentDay))
            {
                minDay = Math.Min(currentDay, minDay);
                right = currentDay - 1;
            }
            else
            {
                left = currentDay + 1;
            }
        }

        return minDay;
    }    
}
