namespace LeetcodeGrind.Solutions;

// 2409. Count Days Spent Together
public class P2409
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        var startA = arriveAlice.Split('-');
        var startDateA = new DateTime(2021, int.Parse(startA[0]), int.Parse(startA[1]));
        var endA = leaveAlice.Split('-');
        var endDateA = new DateTime(2021, int.Parse(endA[0]), int.Parse(endA[1]));

        var startB = arriveBob.Split('-');
        var startDateB = new DateTime(2021, int.Parse(startB[0]), int.Parse(startB[1]));
        var endB = leaveBob.Split('-');
        var endDateB = new DateTime(2021, int.Parse(endB[0]), int.Parse(endB[1]));

        int overlap = 0;
        if (endDateA < startDateB || endDateB < startDateA)
        {
            overlap = 0;
        }
        else if (startDateA <= startDateB && endDateA >= endDateB)
        {
            overlap = (endDateB - startDateB).Days + 1;
        }
        else if (startDateB <= startDateA && endDateB >= endDateA)
        {
            overlap = (endDateA - startDateA).Days + 1;
        }
        else if (startDateB > startDateA && startDateB <= endDateA)
        {
            overlap = (endDateA - startDateB).Days + 1;
        }
        else if (startDateA > startDateB && startDateA <= endDateB)
        {
            overlap = (endDateB - startDateA).Days + 1;
        }

        return overlap;
    }
}
