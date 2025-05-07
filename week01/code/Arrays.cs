public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. First, I'll make an array that has the same number of spots as the 'length' input.
        double[] multiples = new double[length];
        // 2. Then, I’ll go through each index in the array using a loop.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate the (i+1)-th multiple
        }
        // 3. For each spot, I’ll multiply the starting number by (index + 1) to get the next multiple.
        //    (So the first one is number * 1, then number * 2, and so on.)
        // 4. I’ll save each result into the array as I go.
        // 5. After the loop is done, I’ll return the array with all the multiples.

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. I will take the last 'amount' of numbers from the list.
        List<int> endPart = data.GetRange(data.Count - amount, amount);

        // 2. I will take the rest of the numbers from the start of the list.
        List<int> startPart = data.GetRange(0, data.Count - amount);
        // 3. I will clear the list to start fresh.
        data.Clear();
        // 4. I will add the last numbers to the front of the list.
        data.AddRange(endPart);
        // 5. Then I will add the rest of the numbers after that.
        data.AddRange(startPart);
        //
        // This will make the list look like it has been rotated to the right.
    }
}
