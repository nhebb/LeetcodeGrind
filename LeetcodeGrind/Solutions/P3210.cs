namespace LeetcodeGrind.Solutions;

// 3210. Find the Encrypted String
public class P3210
{
    public string GetEncryptedString(string s, int k)
    {
        k = k % s.Length;
        return s.Substring(k) + s.Substring(0, k);
    }
}
