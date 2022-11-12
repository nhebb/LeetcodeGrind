using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetcodeGrind.ArraysAndHashing;

namespace LeetcodeGrindTests;

public class SnapShotArrayTests
{
    [Fact]
    public void SnapShots_0_and_2_Should_Return_15_For_Index_0()
    {        
        /*  Test case:
         *  ["SnapshotArray","set","snap","snap","snap","get","snap","snap","get"]
            [[1],[0,15],[],[],[],[0,2],[],[],[0,0]]
         */

        var expected = 15;

        var ssa = new SnapshotArray(1);
        ssa.Set(0, 15);
        ssa.Snap();
        ssa.Snap();
        ssa.Snap();
        var actual1 = ssa.Get(0, 2);
        ssa.Snap();
        ssa.Snap();
        var actual2 = ssa.Get(0, 0);

        Assert.Equal(actual1, actual2);
        Assert.Equal(expected, actual1);
    }

}
