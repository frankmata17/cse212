public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the value with the highest priority (lowest priority number).
    /// In case of a tie, the item that was added first is dequeued first (FIFO behavior).
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;

        // Find the item with the highest priority (lowest number)
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority < _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
            // If equal priority, keep the earlier (FIFO) — do not update index
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
