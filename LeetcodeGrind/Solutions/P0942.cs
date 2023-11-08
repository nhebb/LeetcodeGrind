namespace LeetcodeGrind.Solutions;

// 942. DI String Match
public class P0942
{
    public int[] DiStringMatch(string s)
    {
        var i = 0;
        var j = s.Length;
        var ans = new int[s.Length + 1];

        for (var k = 0; k < s.Length; k++)
        {
            if (s[k] == 'I')
            {
                ans[k] = i;
                i++;
            }
            else
            {
                ans[k] = j;
                j--;
            }
        }
        ans[^1] = i;
        return ans;
    }
}
