namespace LeetcodeGrind.Solutions;

// 881. Boats to Save People
public class P0881
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        var i = 0;
        var j = people.Length - 1;
        var count = 0;

        while (i <= j)
        {
            count++;

            if (i == j)
                break;

            if (people[i] + people[j] <= limit)
                i++;
            j--;
        }
        return count;
    }
}
