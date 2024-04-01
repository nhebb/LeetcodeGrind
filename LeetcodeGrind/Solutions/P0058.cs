namespace LeetcodeGrind.Solutions;

// 58. Length of Last Word
public class P0058
{
    public int LengthOfLastWord(string s)
    {
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries)[^1].Length;
    }

    public int LengthOfLastWord2(string s)
    {
        // The 'hard' way - without using Split()
        var length = 0;
        var inString = false;
        var count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                if (inString)
                {
                    inString = false;
                    length = count;
                    count = 0;
                }
                continue;
            }
            inString = true;
            count++;
        }

        if (count > 0) 
            length = count;

        return length;
    }
}

