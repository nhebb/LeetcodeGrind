using System.Reflection.Emit;

namespace LeetcodeGrind.Solutions;

// 2751. Robot Collisions
public class P2751
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        if (!directions.Any(d => d == 'L') ||
            !directions.Any(d => d == 'R'))
        {
            return healths;
        }

        // Create 2 copies of positions, so the original
        // positions can be used to sort health, directions,
        // and indexes.
        var positions2 = new int[positions.Length];
        Array.Copy(positions, positions2, positions.Length);
        var positions3 = new int[positions.Length];
        Array.Copy(positions, positions3, positions.Length);

        Array.Sort(positions, healths);

        var directions2 = directions.ToCharArray();
        Array.Sort(positions2, directions2);

        var indexes = Enumerable.Range(0, healths.Length).ToArray();
        Array.Sort(positions3, indexes);

        var stack = new Stack<(char direction, int health, int index)>();
        for (int i = 0; i < healths.Length; i++)
        {
            var dir = directions2[i];
            if (dir == 'R')
            {
                stack.Push(('R', healths[i], indexes[i]));
            }
            else if (stack.Count == 0 || stack.Peek().direction == 'L')
            {
                stack.Push(('L', healths[i], indexes[i]));
            }
            else if (stack.Count > 0 && stack.Peek().direction == 'R' &&
                     stack.Peek().health > healths[i])
            {
                var robot = stack.Pop();
                robot.health--;
                stack.Push(robot);
            }
            else if (stack.Count > 0 && stack.Peek().direction == 'R' &&
                     stack.Peek().health == healths[i])
            {
                _ = stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && stack.Peek().direction == 'R' &&
                       stack.Peek().health < healths[i])
                {
                    healths[i]--;
                    _ = stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek().direction == 'L')
                {
                    stack.Push(('L', healths[i], indexes[i]));
                }
                else if (stack.Peek().health == healths[i])
                {
                    _ = stack.Pop();
                }
                else if (stack.Count > 0 && stack.Peek().direction == 'R' &&
                         stack.Peek().health > healths[i])
                {
                    var robot = stack.Pop();
                    robot.health--;
                    stack.Push(robot);
                }
            }
        }

        var result = new List<(int index, int health)>();
        while (stack.Count > 0)
        {
            var robot = stack.Pop();
            result.Add((robot.index, robot.health));
        }

        return result.OrderBy(r => r.index)
                     .Select(r => r.health)
                     .ToList();
    }


    private class Robot
    {
        public int Index { get; set; }
        public int Position { get; set; }
        public int Health { get; set; }
        public char Direction { get; set; }
        public Robot(int index, int position, int health, char direction)
        {
            Index = index;
            Position = position;
            Health = health;
            Direction = direction;
        }
    }

    // Class based approach. Slightly slower than the array approach above.
    public IList<int> SurvivedRobotsHealths2(int[] positions, int[] healths, string directions)
    {
        var unsortedRobots = new List<Robot>();
        for (int i = 0; i < positions.Length; i++)
        {
            unsortedRobots.Add(new Robot(i, positions[i], healths[i], directions[i]));
        }
        var robots = unsortedRobots.OrderBy(r => r.Position);

        var stack = new Stack<Robot>();
        foreach (var robot in robots)
        {
            if (robot.Direction == 'R')
            {
                stack.Push(robot);
            }
            else if (stack.Count == 0 ||
                     stack.Peek().Direction == 'L')
            {
                stack.Push(robot);
            }
            else if (stack.Count > 0 && stack.Peek().Direction == 'R' &&
                     stack.Peek().Health > robot.Health)
            {
                stack.Peek().Health--;
            }
            else if (stack.Count > 0 && stack.Peek().Direction == 'R' &&
                     stack.Peek().Health == robot.Health)
            {
                _ = stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && stack.Peek().Direction == 'R' &&
                       stack.Peek().Health < robot.Health)
                {
                    robot.Health--;
                    _ = stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek().Direction == 'L')
                {
                    stack.Push(robot);
                }
                else if (stack.Peek().Health == robot.Health)
                {
                    _ = stack.Pop();
                }
                else if (stack.Count > 0 && stack.Peek().Direction == 'R' &&
                         stack.Peek().Health > robot.Health)
                {
                    stack.Peek().Health--;
                }
            }
        }

        return stack.ToList()
                    .OrderBy(r => r.Index)
                    .Select(r => r.Health)
                    .ToList();
    }
}
