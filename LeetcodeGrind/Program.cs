namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[[],[],[],[],[],[],[]]
            //var points = new int[7][];

            //points[0] = new int[] { 9, 12 };
            //points[1] = new int[] { 1, 10 };
            //points[2] = new int[] { 4, 11 };
            //points[3] = new int[] { 8, 12 };
            //points[4] = new int[] { 3, 9 };
            //points[5] = new int[] { 6, 9 };
            //points[6] = new int[] { 6, 7 };

            var points = new int[4][];
            //points[0] = new int[] { 10, 16 };
            //points[1] = new int[] { 2, 8 };
            //points[2] = new int[] { 1, 6 };
            //points[3] = new int[] { 7, 12 };

            points[0] = new int[] { 1, 2 };
            points[1] = new int[] { 3, 4 };
            points[2] = new int[] { 5, 6 };
            points[3] = new int[] { 7, 8 };

            var tp = new TwoPointers.TwoPointers();
            var res = tp.SmallestNumber("IIIDIDDD");
            Console.WriteLine(res);
        }
    }
}