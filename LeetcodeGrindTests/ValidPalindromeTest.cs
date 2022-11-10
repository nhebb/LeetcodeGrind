using LeetcodeGrind.TwoPointers;

namespace LeetcodeGrindTests;

public class ValidPalindromeTest
{
    private readonly TwoPointers _twoPointers;

    public ValidPalindromeTest()
    {
        _twoPointers = new();
    }

    [Fact]
    public void Known_Good_Passes()
    {
        var s1 = "ebcbbececabbacecbbcbe";

        var result = _twoPointers.ValidPalindrome(s1);

        Assert.True(result);
    }

    [Fact]
    public void Known_Bad_Fails()
    {
        var s1 = "abc";

        var result = _twoPointers.ValidPalindrome(s1);

        Assert.False(result);
    }

}