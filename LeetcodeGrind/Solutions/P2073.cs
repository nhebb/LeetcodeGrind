namespace LeetcodeGrind.Solutions;

// 2073. Time Needed to Buy Tickets
public class P2073
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var time = 0;
        var i = 0;

        while (tickets[k] > 0)
        {
            if (tickets[i] > 0)
            {
                tickets[i]--;
                time++;
            }
            i = (i + 1) % tickets.Length;
        }

        return time;
    }
}
