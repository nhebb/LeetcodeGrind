namespace LeetcodeGrind.Solutions;

// 2798. Number of Employees Who Met the Target
public class P2798
{
    public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
    {
        return hours.Count(x => x >= target);
    }
}
