namespace LeetcodeGrind.Solutions;

// 2651. Calculate Delayed Arrival Time
public class P2651
{
    public int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
    {
        return (arrivalTime + delayedTime) % 24;
    }
}
