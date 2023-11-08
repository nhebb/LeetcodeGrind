namespace LeetcodeGrind.Solutions;

// 649. Dota2 Senate
public class P0649
{
    public string PredictPartyVictory(string senate)
    {
        var q = new Queue<char>();
        var dCount = 0;
        var rCount = 0;

        for (int i = 0; i < senate.Length; i++)
        {
            q.Enqueue(senate[i]);
            if (senate[i] == 'D')
                dCount++;
            else
                rCount++;
        }

        var dSkip = 0;
        var rSkip = 0;
        while (q.Count > 0 && dCount > 0 && rCount > 0)
        {
            var senator = q.Dequeue();
            if (senator == 'D')
            {
                if (dSkip > 0)
                {
                    dSkip--;
                    dCount--;
                }
                else
                {
                    rSkip++;
                    q.Enqueue(senator);
                }
            }
            else
            {
                if (rSkip > 0)
                {
                    rSkip--;
                    rCount--;
                }
                else
                {
                    dSkip++;
                    q.Enqueue(senator);
                }
            }
        }

        return dCount > 0 ? "Dire" : "Radiant";
    }
}
