namespace LeetcodeGrind.Solutions;

// 1103. Distribute Candies to People
public class P1103
{
    public int[] DistributeCandies(int candies, int num_people)
    {
        var answer = new int[num_people];
        var i = 0;
        var n = 1;

        while (candies > 0)
        {
            answer[i] += Math.Min(candies, n);
            candies -= n;
            n++;
            i = (i + 1) % num_people;
        }

        return answer;
    }
}
