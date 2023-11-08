namespace LeetcodeGrind.Solutions;

// 1146. Snapshot Array
/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */

public class SnapshotArray
{
    private class SnapShot
    {
        public int SnapId { get; private set; }
        public int Index { get; private set; }
        public int Value { get; private set; }

        public SnapShot(int snapId, int index, int value)
        {
            SnapId = snapId;
            Index = index;
            Value = value;
        }
    }

    int[] _arr;
    List<SnapShot> _snapshots = new();
    HashSet<int> _updatedIndices = new();
    int _snapId = 0;

    public SnapshotArray(int length)
    {
        _arr = new int[length];
    }

    // sets the element at the given index to be equal to val.
    public void Set(int index, int val)
    {
        _arr[index] = val;
        _updatedIndices.Add(index);
    }

    // takes a snapshot of the array and returns the snap_id:
    // the total number of times we called snap() minus 1.
    public int Snap()
    {
        foreach (var index in _updatedIndices)
        {
            _snapshots.Add(new SnapShot(_snapId, index, _arr[index]));
        }
        _updatedIndices.Clear();
        _snapId++;
        return _snapId - 1;
    }

    // returns the value at the given index, at the time we took
    // the snapshot with the given snap_id
    public int Get(int index, int snap_id)
    {
        var snapshot = _snapshots
            .Where(x => x.Index == index && x.SnapId == snap_id)
            .FirstOrDefault();

        if (snapshot == null)
        {
            snapshot = _snapshots
                .Where(x => x.Index == index && x.SnapId <= snap_id)
                .OrderByDescending(x => x.SnapId)
                .FirstOrDefault();
        }
        return snapshot != null ? snapshot.Value : 0;
    }
}
