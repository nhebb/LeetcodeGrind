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

        var lastQueueCount = 0;
        while (j < sandwiches.Length && q.Count > 0 && q.Count != lastQueueCount)
        {
            lastQueueCount = q.Count;

            for (int i = 0; i < lastQueueCount && j < sandwiches.Length; i++)
            {
                var student = q.Dequeue();
                if (student == sandwiches[j])
                {
                    j++;
                }
                else
                {
                    q.Enqueue(student);
                }
            }
            
        }

        return q.Count;
    }
}
