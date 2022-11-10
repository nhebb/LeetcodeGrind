using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.TwoPointers;

public class TwoPointers
{
    // 125. Valid Palindrome
    public bool IsPalindrome(string s)
    {
        s = s.ToLowerInvariant();
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
        }

        string text = sb.ToString();
        string reverse = string.Join("", text.ToCharArray().Reverse());

        return text == reverse;
    }


    // 680. Valid Palindrome II
    public bool ValidPalindrome(string s)
    {
        if (s.Length <= 2) return true;
        if (s == string.Join("", s.Reverse())) return true;

        var i = 0;
        var j = s.Length - 1;
        var skip = 0;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                skip++;
                if (skip > 1)
                    return false;

                if (s[i] == s[j - 1])
                    j--;
                else if (s[i + 1] == s[j])
                    i++;
                else
                    return false;
            }
            i++;
            j--;
        }
        return true;
    }

    // 344. Reverse String
    public void ReverseString(char[] s)
    {
        if (s == null || s.Length == 1) return;
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
           (s[i], s[j]) = (s[j], s[i]);
            i++;
            j--;
        }
    }


    // 283. Move Zeroes
    public void MoveZeroes(int[] nums)
    {
        int lastIndex = nums.Length - 1;
        while (lastIndex >= 0 && nums[lastIndex] == 0)
        {
            lastIndex--;
        }

        for (int i = lastIndex - 1; i >= 0; i--)
        {
            if (nums[i] == 0)
            {
                for (int j = i; j < lastIndex; j++)
                {
                    nums[j] = nums[j + 1];
                }
                nums[lastIndex] = 0;
                lastIndex--;
            }
        }
    }


    // 26. Remove Duplicates from Sorted Array
    public int RemoveDuplicates(int[] nums)
    {
        if (nums == null) { return 0; }

        int len = nums.Length;
        if (len <= 1) { return len; }

        for (int i = nums.Length - 1; i >= 1; i--)
        {
            if (nums[i - 1] == nums[i])
            {
                for (int j = i - 1; j < len - 1; j++)
                {
                    nums[j] = nums[j + 1];
                }
                len--;
            }
        }
        return len;
    }


    // 167. Two Sum II - Input Array Is Sorted
    public int[] TwoSumII(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;
        while (true)
        {
            var sum = numbers[i] + numbers[j];
            if (sum == target)
                return new int[] { i + 1, j + 1 };
            else if (sum < target)
                i++;
            else
                j--;
        }
    }


    // 15. 3Sum
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> triplets = new List<IList<int>>();

        if (nums == null || nums.Length < 3) return triplets;

        Array.Sort(nums);

        int i = 0;
        while (i < nums.Length - 2)
        {
            var target = -1 * nums[i];
            var j = i + 1;
            var k = nums.Length - 1;

            while (j < k)
            {
                if (nums[j] + nums[k] > target)
                    k--;
                else if (nums[j] + nums[k] < target)
                    j++;
                else
                {
                    var triplet = new List<int>() { nums[i], nums[j], nums[k] };
                    triplets.Add(triplet);

                    // skip mid and end duplicates
                    while (j < k && nums[j] == triplet[1])
                        j++;
                    while (j < k && nums[k] == triplet[2])
                        k--;
                }
            }

            // skip target duplicates
            var skipVal = nums[i];
            while (i < nums.Length - 2 && nums[i] == skipVal)
                i++;
        }
        return triplets;
    }


    // 11. Container With Most Water
    public int MaxArea(int[] height)
    {
        var maxArea = 0;
        var x1 = 0;
        var x2 = height.Length - 1;

        while (x1 < x2)
        {
            maxArea = Math.Max(maxArea, Math.Min(height[x1], height[x2]) * (x2 - x1));
            if (height[x1] > height[x2])
            {
                x2--;
            }
            else
            {
                x1++;
            }
        }
        return maxArea;
    }


    // 42. Trapping Rain Water
    public int Trap(int[] height)
    {
        var water = 0;
        var maxL = height[0];
        var maxR = height[^1];
        var i = 0;
        var j = height.Length - 1;
        while (i < j)
        {
            if (maxL < maxR)
            {
                i++;
                maxL = Math.Max(maxL, height[i]);
                water += maxL - height[i];
            }
            else
            {
                j--;
                maxR = Math.Max(maxR, height[j]);
                water += maxR - height[j];
            }
        }
        return water;
    }
}
