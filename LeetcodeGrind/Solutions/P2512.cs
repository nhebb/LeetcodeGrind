namespace LeetcodeGrind.Solutions;

// 2512. Reward Top K Students
public class P2512
{
    private class Student
    {
        public int Id { get; private set; }
        public int Score { get; private set; }
        public Student(int id, int score)
        {
            Id = id;
            Score = score;
        }
    }
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
    {
        var hsPos = positive_feedback.ToHashSet();
        var hsNeg = negative_feedback.ToHashSet();
        var students = new List<Student>();

        for (int i = 0; i < report.Length; i++)
        {
            var words = report[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var score = 0;
            foreach (var word in words)
            {
                if (hsPos.Contains(word))
                    score += 3;
                else if (hsNeg.Contains(word))
                    score--;
            }
            students.Add(new Student(student_id[i], score));
        }

        return students.OrderByDescending(x => x.Score)
                       .ThenBy(x => x.Id)
                       .Select(x => x.Id)
                       .Take(k)
                       .ToList();
    }
}
