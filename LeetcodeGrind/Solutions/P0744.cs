namespace LeetcodeGrind.Solutions;

// 744. Find Smallest Letter Greater Than Target
public class P0744
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        if (target >= letters[^1])
            return letters[0];

        var index = Array.BinarySearch(letters, target);
        if (index < 0)
            index = ~index;

        while (target == letters[index])
            index++;

        return letters[index];
    }

    public char NextGreatestLetterLINQ(char[] letters, char target)
    {
        if (target >= letters[^1])
            return letters[0];

        return letters.First(c => c > target);
    }
}
