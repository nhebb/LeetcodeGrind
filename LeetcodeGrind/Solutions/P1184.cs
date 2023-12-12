using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1184. Distance Between Bus Stops
public class P1184
{
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
        if (start == destination)
        {
            return 0;
        }
        else if (start > destination)
        {
            // Swap so we don't have to mess with mod indexing
            (start, destination) = (destination, start);
        }

        var forward = 0;
        for (int i = start; i < destination; i++)
        {
            forward += distance[i];
        }

        var total = distance.Sum();

        return Math.Min(forward, total - forward);
    }
}
