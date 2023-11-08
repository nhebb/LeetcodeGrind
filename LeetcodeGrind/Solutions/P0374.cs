namespace LeetcodeGrind.Solutions;

// 374. Guess Number Higher or Lower
public class P0374
{
    // The LC test runner provides the guess() function.
    // The following is just a stub so VS doesn't
    // show an error.
    private int guess(int num) => -1;

    public int GuessNumber(int n)
    {
        var min = 0;
        var max = n;
        var mid = n / 2;
        var result = guess(mid);
        while (true)
        {
            if (result == 0)
                break;

            if (result < 0)
                max = mid - 1;
            else
                min = mid + 1;

            mid = min + (max - min) / 2;
            result = guess(mid);
        }

        return mid;
    }
}
