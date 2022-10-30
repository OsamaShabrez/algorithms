namespace algorithms;

public static class MergeSort
{
    // Best case O(N LogN)
    // Worst case O(N logN)
    // Space complexity O(n)
    public static int[] Iterative(int[] array)
    {
        var start = 0;
        var end = array.Length - 1;
        var copyArray = new int[array.Length];
        Array.Copy(array, 0, copyArray, 0, array.Length);

        for (var i = 1; i <= end - start; i *= 2)
        for (var j = start; j < end; j += i * 2)
        {
            var low = j;
            var mid = j + i - 1;
            var top = Math.Min(j + i * 2 - 1, end);

            InternalIterative(array, copyArray, low, mid, top);
        }

        return array;
    }

    private static void InternalIterative(int[] array, int[] copyArray, int low, int mid, int top)
    {
        var i = low;
        var j = mid + 1;
        var k = low;

        while (i <= mid && j <= top)
            if (array[i] < array[j])
                copyArray[k++] = array[i++];
            else
                copyArray[k++] = array[j++];

        while (i < array.Length && i <= mid)
            copyArray[k++] = array[i++];

        for (var z = low; z <= top; z++)
            array[z] = copyArray[z];
    }

    public static int[] Recursive(int[] array)
    {
        if (array.Length == 1)
            return array;

        var left = array.Take(array.Length / 2).ToArray();
        var right = array.Skip(array.Length / 2).ToArray();

        Recursive(left);
        Recursive(right);

        int idxArray = 0, idxLeft = 0, idxRight = 0;
        while (idxLeft < left.Length && idxRight < right.Length)
            if (left[idxLeft] < right[idxRight])
                array[idxArray++] = left[idxLeft++];
            else
                array[idxArray++] = right[idxRight++];

        while (idxLeft < left.Length)
            array[idxArray++] = left[idxLeft++];

        while (idxRight < right.Length)
            array[idxArray++] = right[idxRight++];

        return array;
    }
}