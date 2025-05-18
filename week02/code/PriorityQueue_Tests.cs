using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
{
    var pq = new PriorityQueue();
    pq.Enqueue("Task A", 3);
    pq.Enqueue("Task B", 2);
    pq.Enqueue("Task C", 1);

    Assert.AreEqual("Task C", pq.Dequeue());
}

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
{
    var pq = new PriorityQueue();
    pq.Enqueue("X", 5);
    pq.Enqueue("Y", 5);
    pq.Enqueue("Z", 5);

    var result1 = pq.Dequeue();
    var result2 = pq.Dequeue();
    var result3 = pq.Dequeue();

    CollectionAssert.AreEqual(new List<string> { result1, result2, result3 }, new List<string> { "X", "Y", "Z" });
}

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them
    // Expected Result: Items with highest priority are dequeued first, ties resolved by order of insertion (FIFO)
    // Defect(s) Found: None
    public void TestPriorityQueue_DequeueOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 1);
        priorityQueue.Enqueue("E", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        priorityQueue.Enqueue("X", 10);
        Assert.AreEqual("X", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });
    }
}
