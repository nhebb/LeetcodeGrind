namespace LeetcodeGrind.Solutions;

// 1052. Grumpy Bookstore Owner
public class P1052
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        if (minutes >= customers.Length)
        {
            return customers.Sum();
        }

        // Get base satisfaction for customers + initial window.
        var satisfied = 0;
        for (int i = 0; i < customers.Length; i++)
        {
            if (i < minutes || grumpy[i] == 0)
            {
                satisfied += customers[i];
            }
        }

        // Use sliding window to add // remove satisfaction.
        var maxSatisfied = satisfied;
        for (int i = 1, j = minutes; j < customers.Length; i++, j++)
        {
            if (grumpy[i - 1] == 1)
            {
                satisfied -= customers[i - 1];
            }
            if (grumpy[j] == 1)
            {
                satisfied += customers[j];
            }

            maxSatisfied = Math.Max(maxSatisfied, satisfied);
        }

        return maxSatisfied;
    }
}
