namespace algorithms;

public static class SelectionSort
{
    // Best case O(N^2)
    // Worst case O(N^2)
    // Space complexity O(1)
    public static int[] Iterative(int[] array)
    {
        for (var sorted = 0; sorted < array.Length; sorted++)
        {
            var minIdx = sorted;
            for (var current = sorted + 1; current < array.Length; current++)
                if (array[current] < array[minIdx])
                    minIdx = current;

            (array[sorted], array[minIdx]) = (array[minIdx], array[sorted]);
        }

        return array;
    }

    public static int[] Recursive(int[] array)
    {
        return InternalRecursive(array, 0);
    }

    private static int[] InternalRecursive(int[] array, int sorted)
    {
        if (array.Length == sorted)
            return array;

        var minIdx = FindMinimum(array, sorted, array.Length - 1);
        if (sorted != minIdx)
            (array[sorted], array[minIdx]) = (array[minIdx], array[sorted]);

        return InternalRecursive(array, sorted + 1);
    }

    private static int FindMinimum(int[] array, int current, int max)
    {
        if (current == max)
            return current;


        var next = FindMinimum(array, current + 1, max);
        return array[current] < array[next] ? current : next;
    }
}