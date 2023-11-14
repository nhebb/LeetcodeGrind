namespace LeetcodeGrind.Solutions;

// 949. Largest Time for Given Digits
public class P0949
{
    public string LargestTimeFromDigits(int[] arr)
    {
        if (arr.Min() >= 3) return "";

        var time = new List<int>();
        var chosen = new bool[4];
        var maxHrs = 0;
        var maxMins = 0;

        void Backtrack()
        {
            for (int i = 0; i < 4; i++)
            {
                if (chosen[i])
                    continue;

                time.Add(arr[i]);
                if (time.Count == 4)
                {
                    var hrs = time[0] * 10 + time[1];
                    var mins = time[2] * 10 + time[3];
                    if ((hrs > maxHrs && hrs < 24 && mins < 60) ||
                        (hrs == maxHrs && mins > maxMins && mins < 60))
                    {
                        maxHrs = hrs;
                        maxMins = mins;
                    }
                }
                else
                {
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                }
                time.RemoveAt(time.Count - 1);
            }
        }

        Backtrack();

        if (maxHrs == 0 && maxMins == 0 && arr.Any(x => x > 0))
            return "";

        return maxHrs.ToString("00") + ":" + maxMins.ToString("00");
    }
}
