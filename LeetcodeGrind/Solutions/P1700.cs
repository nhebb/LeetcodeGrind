namespace LeetcodeGrind.Solutions;

// 1700. Number of Students Unable to Eat Lunch
public class P1700
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var q = new Queue<int>();
        for (int i = 0; i < students.Length; i++)
        {
            q.Enqueue(students[i]);
        }

        var seen = new HashSet<int>();
        int j = 0;



        return 0;
    }
}
