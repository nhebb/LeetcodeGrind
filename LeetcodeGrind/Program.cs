namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var points = new List<int[]>();

            points.Add(new int[] { 7, 3 });
            points.Add(new int[] { 19, 19 });
            points.Add(new int[] { -16, 3 });
            points.Add(new int[] { 13, 17 });
            points.Add(new int[] { -18, 1 });
            points.Add(new int[] { -18, -17 });
            points.Add(new int[] { 13, -3 });
            points.Add(new int[] { 3, 7 });
            points.Add(new int[] { -11, 12 });
            points.Add(new int[] { 7, 19 });
            points.Add(new int[] { 19, -12 });
            points.Add(new int[] { 20, -18 });
            points.Add(new int[] { -16, -15 });
            points.Add(new int[] { -10, -15 });
            points.Add(new int[] { -16, -18 });
            points.Add(new int[] { -14, -1 });
            points.Add(new int[] { 18, 10 });
            points.Add(new int[] { -13, 8 });
            points.Add(new int[] { 7, -5 });
            points.Add(new int[] { -4, -9 });
            points.Add(new int[] { -11, 2 });
            points.Add(new int[] { -9, -9 });
            points.Add(new int[] { -5, -16 });
            points.Add(new int[] { 10, 14 });
            points.Add(new int[] { -3, 4 });
            points.Add(new int[] { 1, -20 });
            points.Add(new int[] { 2, 16 });
            points.Add(new int[] { 0, 14 });
            points.Add(new int[] { -14, 5 });
            points.Add(new int[] { 15, -11 });
            points.Add(new int[] { 3, 11 });
            points.Add(new int[] { 11, -10 });
            points.Add(new int[] { -1, -7 });
            points.Add(new int[] { 16, 7 });
            points.Add(new int[] { 1, -11 });
            points.Add(new int[] { -8, -3 });
            points.Add(new int[] { 1, -6 });
            points.Add(new int[] { 19, 7 });
            points.Add(new int[] { 3, 6 });
            points.Add(new int[] { -1, -2 });
            points.Add(new int[] { 7, -3 });
            points.Add(new int[] { -6, -8 });
            points.Add(new int[] { 7, 1 });
            points.Add(new int[] { -15, 12 });
            points.Add(new int[] { -17, 9 });
            points.Add(new int[] { 19, -9 });
            points.Add(new int[] { 1, 0 });
            points.Add(new int[] { 9, -10 });
            points.Add(new int[] { 6, 20 });
            points.Add(new int[] { -12, -4 });
            points.Add(new int[] { -16, -17 });
            points.Add(new int[] { 14, 3 });
            points.Add(new int[] { 0, -1 });
            points.Add(new int[] { -18, 9 });
            points.Add(new int[] { -15, 15 });
            points.Add(new int[] { -3, -15 });
            points.Add(new int[] { -5, 20 });
            points.Add(new int[] { 15, -14 });
            points.Add(new int[] { 9, -17 });
            points.Add(new int[] { 10, -14 });
            points.Add(new int[] { -7, -11 });
            points.Add(new int[] { 14, 9 });
            points.Add(new int[] { 1, -1 });
            points.Add(new int[] { 15, 12 });
            points.Add(new int[] { -5, -1 });
            points.Add(new int[] { -17, -5 });
            points.Add(new int[] { 15, -2 });
            points.Add(new int[] { -12, 11 });
            points.Add(new int[] { 19, -18 });
            points.Add(new int[] { 8, 7 });
            points.Add(new int[] { -5, -3 });
            points.Add(new int[] { -17, -1 });
            points.Add(new int[] { -18, 13 });
            points.Add(new int[] { 15, -3 });
            points.Add(new int[] { 4, 18 });
            points.Add(new int[] { -14, -15 });
            points.Add(new int[] { 15, 8 });
            points.Add(new int[] { -18, -12 });
            points.Add(new int[] { -15, 19 });
            points.Add(new int[] { -9, 16 });
            points.Add(new int[] { -9, 14 });
            points.Add(new int[] { -12, -14 });
            points.Add(new int[] { -2, -20 });
            points.Add(new int[] { -3, -13 });
            points.Add(new int[] { 10, -7 });
            points.Add(new int[] { -2, -10 });
            points.Add(new int[] { 9, 10 });
            points.Add(new int[] { -1, 7 });
            points.Add(new int[] { -17, -6 });
            points.Add(new int[] { -15, 20 });
            points.Add(new int[] { 5, -17 });
            points.Add(new int[] { 6, -6 });
            points.Add(new int[] { -11, -8 });


            var math = new MathAndGeometry.MathAndGeometry();
            var res = math.MaxPoints(points.ToArray());
            Console.WriteLine(res);
        }
    }
}