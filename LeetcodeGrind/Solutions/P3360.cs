namespace LeetcodeGrind.Solutions;

// 3360. Stone Removal Game
public class P3360
{
    public bool CanAliceWin(int n)
    {
        var stones = 10;
        var alice = true;

        while (n >= stones)
        {
            n -= stones;
            stones--;
            alice = !alice;
        }

        return !alice;
    }
}
