namespace LeetcodeGrind.Solutions;

// 1450. Number of Students Doing Homework at a Given Time
public class P1450
{
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        var count = 0;

        for (int i = 0; i < startTime.Length; i++)
        {
            if (startTime[i] <= queryTime && queryTime <= endTime[i])
            {
                count++;
            }
        }

        return count;
    }
}
