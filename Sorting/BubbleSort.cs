namespace algorithms;

public static class BubbleSort
{
    // Best case O(n)
    // Worst case O(n^2)
    // Space complexity O(1)
    public static int[] Iterative(int[] array)
    {
        for (var writer = 0; writer < array.Length; writer++)
        {
            var flag = true;
            for (var sorter = 0; sorter < array.Length - writer - 1; sorter++)
                if (array[sorter] > array[sorter + 1])
                {
                    flag = false;
                    // swap via deconstruction
                    (array[sorter + 1], array[sorter]) = (array[sorter], array[sorter + 1]);
                }

            if (flag)
                break;
        }

        return array;
    }

    public static int[] Recursive(int[] array)
    {
        return InternalRecursive(array, array.Length);
    }

    private static int[] InternalRecursive(int[] array, int length)
    {
        if (length == 1)
            return array;

        var flag = true;
        for (var sorter = 0; sorter < length - 1; sorter++)
            if (array[sorter] > array[sorter + 1])
            {
                flag = false;
                // swap via deconstruction
                (array[sorter + 1], array[sorter]) = (array[sorter], array[sorter + 1]);
            }

        return flag ? array : InternalRecursive(array, length - 1);
    }
}