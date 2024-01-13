namespace LeetcodeGrind.Solutions;

// 2383. Minimum Hours of Training to Win a Competition
public class P2383
{
    public int MinNumberOfHours(int initialEnergy, int initialExperience,
                                int[] energy, int[] experience)
    {
        var training = 0;
        var needed = 0;

        for (int i = 0; i < energy.Length; i++)
        {
            if (energy[i] >= initialEnergy)
            {
                needed = energy[i] - initialEnergy + 1;
                training += needed;
                initialEnergy += needed;
            }

            if (experience[i] >= initialExperience)
            {
                needed = experience[i] - initialExperience + 1;
                training += needed;
                initialExperience += needed;
            }

            initialEnergy -= energy[i];
            initialExperience += experience[i];
        }

        return training;
    }
}
