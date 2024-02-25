using System.Reflection.Emit;

namespace LeetcodeGrind.Solutions;

// 2092. Find All People With Secret
public class P2092
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        var result = new List<int>();
        var parent = Enumerable.Range(0, n).ToArray();
        parent[firstPerson] = 0;

        Array.Sort(meetings, (x, y) => x[2].CompareTo(y[2]));

        var people = new List<int>();
        var i = 0;
        while (i < meetings.Length)
        {
            var curTime = meetings[i][2];

            people.Clear();
            while (i < meetings.Length && meetings[i][2] == curTime)
            {
                var person1 = meetings[i][0];
                var person2 = meetings[i][1];

                var parent1 = Find(parent, person1);
                var parent2 = Find(parent, person2);
                parent[Math.Max(parent1, parent2)] = Math.Min(parent1, parent2);

                people.Add(person1);
                people.Add(person2);

                i++;
            }

            foreach (var person in people)
            {
                if (Find(parent, person) != 0)
                {
                    parent[person] = person;
                }
            }
        }

        for (int j = 0; j < n; j++)
        {
            if (Find(parent, j) == 0)
            {
                result.Add(j);
            }
        }

        return result;
    }

    private int Find(int[] groups, int index)
    {
        while (index != groups[index])
        {
            index = groups[index];
        }
        return index;
    }
}
