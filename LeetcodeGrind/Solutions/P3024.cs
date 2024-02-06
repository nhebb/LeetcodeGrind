namespace LeetcodeGrind.Solutions;

// 3024. Type of Triangle II
public class P3024
{
    public string TriangleType(int[] nums)
    {
        var a = nums[0];
        var b = nums[1];
        var c = nums[2];

        // Check options from most restrictive to least restrictive
        if (a + b <= c || b + c <= a || a + c <= b)
            return "none";
        else if (a == b && b == c)
            return "equilateral";
        else if (a == b || b == c || a == c)
            return "isosceles";

        return "scalene";
    }
}
