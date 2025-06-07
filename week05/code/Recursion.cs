using System.Collections;
using System.Numerics;


public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int length, string soFar = "")
    {
        if (length == 0)
        {
            results.Add(soFar);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (!soFar.Contains(letters[i]))
            {
                PermutationsChoose(results, letters, length - 1, soFar + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    /// 

    private static Dictionary<int, decimal> climbMemo = new();
    public static decimal CountWaysToClimb(int steps)
    {
        if (steps < 0)
            return 0;
        if (steps == 0)
            return 1;

        if (climbMemo.ContainsKey(steps))
            return climbMemo[steps];

        decimal result = CountWaysToClimb(steps - 1) +
                         CountWaysToClimb(steps - 2) +
                         CountWaysToClimb(steps - 3);

        climbMemo[steps] = result;
        return result;
    }



    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string input, List<string> results)
    {
        WildcardBinaryHelper(input.ToCharArray(), 0, results);
    }

    private static void WildcardBinaryHelper(char[] chars, int index, List<string> results)
    {
        if (index == chars.Length)
        {
            results.Add(new string(chars));
            return;
        }

        if (chars[index] == '*')
        {
            chars[index] = '0';
            WildcardBinaryHelper(chars, index + 1, results);
            chars[index] = '1';
            WildcardBinaryHelper(chars, index + 1, results);
            chars[index] = '*'; // backtrack
        }
        else
        {
            WildcardBinaryHelper(chars, index + 1, results);
        }
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze)
    {
        // List<(int, int)> path = new();
        // bool[,] visited = new bool[maze.Rows, maze.Cols];
        // SolveMazeHelper(maze, 0, 0, path, visited, results);
    }

    // private static void SolveMazeHelper(Maze maze, int row, int col, List<(int, int)> path, bool[,] visited, List<string> results)
    // {
    //     if (!maze.IsValid(row, col) || visited[row, col])
    //         return;

    //     path.Add((row, col));
    //     visited[row, col] = true;

    //     if (maze.IsExit(row, col))
    //     {
    //         results.Add(FormatPath(path));
    //     }
    //     else
    //     {
    //         SolveMazeHelper(maze, row - 1, col, path, visited, results); // up
    //         SolveMazeHelper(maze, row + 1, col, path, visited, results); // down
    //         SolveMazeHelper(maze, row, col - 1, path, visited, results); // left
    //         SolveMazeHelper(maze, row, col + 1, path, visited, results); // right
    //     }

    //     visited[row, col] = false;
    //     path.RemoveAt(path.Count - 1);
    // }

    // private static string FormatPath(List<(int, int)> path)
    // {
    //     return $"<List>{{{string.Join(", ", path.Select(p => $"({p.Item1}, {p.Item2})"))}}}";
    // }
    
}
