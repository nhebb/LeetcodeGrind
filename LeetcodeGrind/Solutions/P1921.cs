using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1921. Eliminate Maximum Number of Monsters
public class P1921
{
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        // Uses the Zip LINQ function to create a list of dist / speed,
        // sorted in increasing order
        var monsters = dist.Zip(speed, (d, s) => d / (double)s)
                           .OrderBy(x => x)
                           .ToList();

        var count = 0;
        var chargeTime = 0;

        foreach (var monster in monsters)
        {
            // If the next closest monster is less than the charge
            // time required, you're dead. Since chargeTime starts
            // at 0, you're guaranteed to get at least 1 shot off.
            if (monster - chargeTime <= 0)
                break;

            count++;
            chargeTime++;
        }

        return count;
    }
}

