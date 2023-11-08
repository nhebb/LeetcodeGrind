namespace LeetcodeGrind.Solutions;

// 2187. Minimum Time to Complete Trips
public class P2187
{
    public long MinimumTime(int[] time, int totalTrips)
    {
        var minTime = time.Min();

        if (totalTrips == 1)
            return minTime;

        if (time.Length == 1)
            return (long)1.0 * totalTrips * time[0];

        long left = minTime;
        long right = (long)totalTrips * minTime;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            // how many trips can be made in elapsed time
            var trips = time.Sum(t => mid / (long)t);

            if (trips >= totalTrips)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
}
