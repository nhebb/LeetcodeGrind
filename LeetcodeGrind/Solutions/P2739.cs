namespace LeetcodeGrind.Solutions;

// 2739. Total Distance Traveled
public class P2739
{
    public int DistanceTraveled(int mainTank, int additionalTank)
    {
        var kilometers = 0;

        while (mainTank >= 5)
        {
            kilometers += 50;
            mainTank -= 5;
            if (additionalTank > 0)
            {
                mainTank++;
                additionalTank--;
            }
        }

        kilometers += mainTank * 10;

        return kilometers;
    }
}
