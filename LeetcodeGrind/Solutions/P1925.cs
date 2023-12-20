namespace LeetcodeGrind.Solutions;

// 1925. Count Square Sum Triples
public class P1925
{
    public int CountTriples(int n)
    {
        var squares = new HashSet<int>();
        for (int i = 1; i <= n; i++)
        {
            squares.Add(i * i);
        }

        var count = 0;
        foreach (var target in squares)
        {
            for (int i = 1; i < target; i++)
            {
                if (squares.Contains(target - i * i))
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Based on the 3, 4, 5 combo
    public int CountTriples2(int n)
    {
        var count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 5 == 0 || i * i <= n)
            {
                count += 2;
            }
        }
        return count;
    }
}
