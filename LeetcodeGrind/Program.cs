using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var target = 842818;
        var position = new int[] { 234601, 340195, 492544, 316935, 100648, 508398, 221368, 782081, 118569, 836954 };
        var speed = new int[] { 170791, 421302, 732827, 311238, 926338, 282167, 792022, 638883, 265667, 978160 };
        var stack = new Stacks.Stacks();

        var res = stack.CarFleet(target, position, speed);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}