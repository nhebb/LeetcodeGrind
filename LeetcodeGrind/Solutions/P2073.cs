namespace LeetcodeGrind.Solutions;

// 2073. Time Needed to Buy Tickets
public class P2073
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var n = tickets.Length;
        var time = 0;
        var i = 0;
        while (true)
        {
            if (tickets[i] > 0)
            {
                tickets[i]--;
                time++;
                if (i == k && tickets[i] == 0)
                {
                    return time;
                }
            }

            i = (i + 1) % n;
        }
    }
}
