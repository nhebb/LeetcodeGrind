namespace LeetcodeGrind.Solutions;

// 1011. Capacity To Ship Packages Within D Days
public class P1011
{
    public int ShipWithinDays(int[] weights, int days)
    {
        if (weights.Length == 1)
            return weights[0];

        var lo = 0;
        var hi = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            if (weights[i] > lo)
                lo = weights[i];
            hi += weights[i];
        }

        var result = hi;

        if (days == 1)
            return result;

        while (lo < hi)
        {
            var mid = lo + (hi - lo) / 2;
            var payload = 0;
            var loadDays = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                if (payload + weights[i] == mid)
                {
                    payload = 0;
                    loadDays++;
                }
                else if (payload + weights[i] > mid)
                {
                    payload = weights[i];
                    loadDays++;
                }
                else
                {
                    payload += weights[i];
                }
            }

            // account for last weight(s)
            if (payload > 0)
                loadDays++;

            if (loadDays <= days)
            {
                result = Math.Min(result, mid);
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }

        return result;
    }
}
