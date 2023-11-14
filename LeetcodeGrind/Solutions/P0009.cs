namespace LeetcodeGrind.Solutions;

// 9. Palindrome Number
public class P0009
{
    public bool IsPalindrome(int x)
    {
        var input = x.ToString();
        int i = 0;
        int j = input.Length - 1;
        while (i < j)
        {
            if (input[i] != input[j])
                return false;
            i++;
            j--;
        }
        return true;
    }
}
