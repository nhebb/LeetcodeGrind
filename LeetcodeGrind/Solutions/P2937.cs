namespace LeetcodeGrind.Solutions;

// 2937. Make Three Strings Equal
public class P2937
{
    public int FindMinimumOperations(string s1, string s2, string s3)
    {
        var maxLen = 0;
        var i = 0;
        while(true)
        {
            if (i == s1.Length 
             || i == s2.Length 
             || i == s3.Length 
             || s1[i] != s2[i]
             || s1[i] != s3[i])
            {
                maxLen = i;
                break;
            }

            i++;
        }

        if (maxLen == 0)
            return -1;

        return (s1.Length - maxLen) + 
               (s2.Length - maxLen) + 
               (s3.Length - maxLen);
    }
}
