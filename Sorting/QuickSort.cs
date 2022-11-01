namespace algorithms;

public static class QuickSort
{
    // Average case O(N logN)
    // Worst case O(N^2)
    // Space complexity O(logN)
    public static int[] Iterative(int[] array)
    {
        var left = 0;
        var right = array.Length - 1;
        var top = -1;
        var stack = new int[array.Length];

        stack[++top] = left;
        stack[++top] = right;

        while (top >= 0)
        {
            right = stack[top--];
            left = stack[top--];

            var p = PartitionIterative(array, left, right);
            if (p - 1 > left)
            {
                stack[++top] = left;
                stack[++top] = p - 1;
            }

            if (p + 1 < right)
            {
                stack[++top] = p + 1;
                stack[++top] = right;
            }
        }

        return array;
    }

    private static int PartitionIterative(int[] array, int left, int right)
    {
        var x = array[right];
        var y = left - 1;

        for (var i = left; i <= right - 1; ++i)
        {
            if (array[i] > x) continue;
            
            ++y;
            (array[y], array[i]) = (array[i], array[y]);
        }
        (array[y + 1], array[right]) = (array[right], array[y + 1]);

        return y + 1;
    }

    public static int[] Recursive(int[] array)
    {
        InternalRecursive(array, 0, array.Length - 1);
        return array;
    }

    private static void InternalRecursive(int[] array, int left, int right)
    {
        if (left >= right)
            return;

        var partition = Partition(array, left, right);
        InternalRecursive(array, left, partition);
        InternalRecursive(array, partition + 1, right);
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivot = SelectPivot(array, left, right);
        var idxLeft = left;
        var idxRight = right;

        while (true)
        {
            while (array[idxLeft] < pivot)
                idxLeft++;

            while (array[idxRight] > pivot)
                idxRight--;

            if (idxLeft >= idxRight)
                return idxRight;

            (array[idxLeft], array[idxRight]) = (array[idxRight], array[idxLeft]);

            idxLeft++;
            idxRight--;
        }
    }

    private static int SelectPivot(int[] array, int left, int right)
    {
        var a = array[left];
        var b = array[left + (right - left) / 2];
        var c = array[right];

        // selecting pivot taking mean value
        return Math.Max(Math.Min(a, b), Math.Min(Math.Max(a, b), c));
    }
}