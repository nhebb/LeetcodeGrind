namespace LeetcodeGrind.Solutions;

// 2491. Divide Players Into Teams of Equal Skill
public class P2491
{
    public long DividePlayers(int[] skill)
    {
        // Note: The following wasn't necessary. Calculate the
        // target based on the first i / j pair and compare it
        // to the rest.
        long sum = (long)(skill.Sum());
        double average = (2.0 * sum) / (double)skill.Length;
        if (!double.IsInteger(average))
            return -1;
        int target = (int)average;

        Array.Sort(skill);
        var i = 0;
        var j = skill.Length - 1;
        long chemistry = 0;

        while (i < j)
        {
            if (skill[i] + skill[j] != target)
            {
                return -1;
            }
            chemistry += skill[i] * skill[j];
            i++;
            j--;
        }

        return chemistry;
    }

    public long DividePlayers2(int[] skill)
    {
        Array.Sort(skill);

        int target = skill[0] + skill[^1];
        long chemistry = skill[0] * skill[^1];

        var i = 1;
        var j = skill.Length - 2;

        while (i < j)
        {
            if (skill[i] + skill[j] != target)
            {
                return -1;
            }

            chemistry += skill[i] * skill[j];
            i++;
            j--;
        }

        return chemistry;
    }
}
