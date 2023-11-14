using LeetcodeGrind.Common;
using System.Diagnostics.Contracts;

namespace LeetcodeGrind.Solutions;

// 278. First Bad Version

// The parent class VersionControl is implemented by Leetcode.
// I made a stub implementation below so VS doesn't show errors
public class VersionControl
{
    public bool IsBadVersion(int version) => true;
}

public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int i = 1;
        int j = n;

        while (i < j)
        {
            int mid = i + (j - i) / 2;

            if (IsBadVersion(mid))
                j = mid;
            else
                i = mid + 1;
        }

        return i;
    }
}