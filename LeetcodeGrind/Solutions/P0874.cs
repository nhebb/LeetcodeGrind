namespace LeetcodeGrind.Solutions;

// 874. Walking Robot Simulation
public class P0874
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        (int dx, int dy) direction = (0, 1);
        (int x, int y) coords = (0, 0);

        var hsObstacles = new HashSet<(int, int)>(obstacles.Length);
        for (int i = 0; i < obstacles.Length; i++)
        {
            hsObstacles.Add((obstacles[i][0], obstacles[i][1]));
        }

        void ChangeDirection(int dir)
        {
            if (dir == -1)
            {
                // turn right 90
                if (direction == (0, 1))
                    direction = (1, 0);
                else if (direction == (1, 0))
                    direction = (0, -1);
                else if (direction == (0, -1))
                    direction = (-1, 0);
                else if (direction == (-1, 0))
                    direction = (0, 1);
            }
            else if (dir == -2)
            {
                // turn left 90
                if (direction == (0, 1))
                    direction = (-1, 0);
                else if (direction == (-1, 0))
                    direction = (0, -1);
                else if (direction == (0, -1))
                    direction = (1, 0);
                else if (direction == (1, 0))
                    direction = (0, 1);
            }
        }

        var max = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] < 0)
            {
                ChangeDirection(commands[i]);
                continue;
            }

            for (int j = 1; j <= commands[i]; j++)
            {
                (int, int) next = (coords.x + direction.dx, coords.y + direction.dy);
                if (hsObstacles.Contains(next))
                {
                    break;
                }
                coords = next;
                max = Math.Max(max, coords.x * coords.x + coords.y * coords.y);
            }
        }

        return max;
    }
}
