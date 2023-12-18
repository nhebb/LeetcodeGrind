namespace LeetcodeGrind.Solutions;

// 621. Task Scheduler
// TODO: Finish this.
public class P0621
{
    private class TaskComparer : IComparer<TaskItem>
    {
        public int Compare(TaskItem a, TaskItem b)
        {
            var curTime = Math.Max(a.Time, b.Time);
            if (a.Time <= curTime && b.Time <= curTime)
            {
                return b.Quantity.CompareTo(a.Quantity);
            }

            if (a.Time < b.Time)
            {
                return -1;
            }
            else if (a.Time == b.Time)
            {
                return b.Quantity.CompareTo(a.Quantity);
            }
            return 1;
        }
    }

    private class TaskItem
    {
        public char Id { get; set; }
        public int Quantity { get; set; }
        public int Time { get; set; }
        public int CurrentTime { get; set; }
        public TaskItem(char id, int qty, int time)
        {
            Id = id;
            Quantity = qty;
            Time = time;
            CurrentTime = 0;
        }
    }

    public int LeastInterval(char[] tasks, int n)
    {
        var taskCounts = tasks.GroupBy(x => x)
                              .ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<TaskItem, TaskItem>(new TaskComparer());
        foreach (var kvp in taskCounts)
        {
            var task = new TaskItem(kvp.Key, kvp.Value, 0);
            pq.Enqueue(task, task);
        }

        var time = 0;
        while (pq.Count > 0)
        {
            if (pq.Peek().Time <= time)
            {
                var task = pq.Dequeue();
                task.Quantity--;
                if (task.Quantity > 0)
                {
                    task.Time = time + n + 1;
                    task.CurrentTime = time;
                    pq.Enqueue(task, task);
                }
            }
            time++;
        }
        return time;
    }
}
