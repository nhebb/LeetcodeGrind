namespace LeetcodeGrind.Solutions;

// 853. Car Fleet
public class P0835
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        // convert position to remaining distance
        for (int i = 0; i < position.Length; i++)
            position[i] = target - position[i];

        // sort ascending by remaining distance with
        // speed sorted in parallel array
        Array.Sort(position, speed);

        // create an array of travel times for each
        // car to reach the target
        var times = new double[position.Length];
        for (int i = 0; i < position.Length; i++)
            times[i] = position[i] / (double)(speed[i]);

        // a car cannot go faster than the car ahead of it, 
        // so set the travel time to the max of itslef and
        // the previous car
        for (int i = 1; i < times.Length; i++)
            times[i] = Math.Max(times[i - 1], times[i]);

        // Count the distinct time groups (fleets)
        return times.Distinct().Count();
    }
}
