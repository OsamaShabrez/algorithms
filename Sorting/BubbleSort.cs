namespace algorithms;

// Best case O(n)
// Worst case O(n^2)
// Space complexity O(1)
public static class BubbleSort
{
    public static int[] Iterative(int[] array)
    {
        for (var writer = 0; writer < array.Length; writer++)
        {
            if (InternalSorter(array, writer))
                break;
        }

        return array;
    }

    private static bool InternalSorter(int[] array, int writer)
    {
        var flag = true;
        for (var sorter = 0; sorter < array.Length - writer - 1; sorter++)
            if (array[sorter] > array[sorter + 1])
            {
                flag = false;
                (array[sorter + 1], array[sorter]) = (array[sorter], array[sorter + 1]);
            }

        return flag;
    }

    public static int[] Recursive(int[] array)
    {
        return InternalRecursive(array, array.Length);
    }

    private static int[] InternalRecursive(int[] array, int length)
    {
        if (length == 1)
            return array;

        // writer is always 0 as length decreases with each recursive call
        return InternalSorter(array, 0) ? array : InternalRecursive(array, length - 1);
    }
}