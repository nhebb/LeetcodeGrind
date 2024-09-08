using System.Collections.Generic;

namespace LeetcodeGrind.Solutions;

// 1894. Find the Student that Will Replace the Chalk
public class P1894
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        // Error: results in overflow
        long sum = chalk.Sum();
        long passes = k / sum;
        long remainder = k - passes * sum;
        int i = 0;

        while (remainder > 0)
        {
            if (chalk[i] > remainder)
                break;
            remainder -= chalk[i];
            i = (i + 1) % chalk.Length;
        }

        return i;
    }

    // Python solution (avoids overflow error w/ C# ):

    //def chalkReplacer(self, chalk: List[int], k: int) -> int:
    //    n = len(chalk)
    //    total = sum(chalk)
    //    passes = k // total
    //    remainder = k - passes * total
    //    i = 0

    //    while remainder > 0:
    //        if chalk[i] > remainder:
    //            break
    //        remainder -= chalk[i]
    //        i = (i + 1) % n

    //    return i

}
