namespace algorithms;

// best case O(N LogN)
// worst case O(N LogN)
// space complexity O(1)
public static class HeapSort
{
    public static int[] Iterative(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] <= array[(i - 1) / 2]) continue;

            var j = i;
            while (array[j] > array[(j - 1) / 2])
            {
                (array[j], array[(j - 1) / 2]) = (array[(j - 1) / 2], array[j]);
                j = (j - 1) / 2;
            }
        }

        for (var i = array.Length - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            
            var j = 0;
            int index;
            do
            {
                index = 2 * j + 1;
                if (index < i - 1 && array[index] < array[index + 1])
                    index++;
                
                if (index < i && array[j] < array[index])
                    (array[j], array[index]) = (array[index], array[j]);

                j = index;
            } while (index < i);
        }

        return array;
    }

    public static int[] Recursive(int[] array)
    {
        var heapSize = array.Length;
        for (var i = (array.Length - 1) / 2; i >= 0; i--)
            InternalRecursive(array, i, heapSize);

        for (var i = array.Length - 1; i > 0; i--)
        {
            (array[i], array[0]) = (array[0], array[i]);
            heapSize--;
            InternalRecursive(array, 0, heapSize);
        }

        return array;
    }

    private static void InternalRecursive(int[] array, int index, int heapSize)
    {
        var left = (index + 1) * 2 - 1;
        var right = (index + 1) * 2;
        var largest = left < heapSize && array[left] > array[index] ? left : index;

        if (right < heapSize && array[right] > array[largest])
            largest = right;

        if (largest == index)
            return;

        (array[index], array[largest]) = (array[largest], array[index]);
        InternalRecursive(array, largest, heapSize);
    }
}