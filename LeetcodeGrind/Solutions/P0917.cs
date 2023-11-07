namespace LeetcodeGrind.Solutions;

public class P0917
{
    // 917. Reverse Only Letters
    public string ReverseOnlyLetters(string s)
    {
        var chars = s.ToCharArray();
        var i = 0;
        var j = s.Length - 1;

        while (i < j)
        {
            while (i < j && !char.IsLetter(chars[i]))
                i++;

            while (i < j && !char.IsLetter(chars[j]))
                j--;

            (chars[i], chars[j]) = (chars[j], chars[i]);

            i++;
            j--;
        }

        return string.Join("", chars);
    }
}
