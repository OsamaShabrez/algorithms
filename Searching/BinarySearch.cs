namespace Searching;

// Time complexity O(LogN)
// Space complexity O(1)
public static class BinarySearch
{
    public static int FindIterative(int[] array, int find)
    {
        var left = 0;
        var right = array.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (array[mid] < find)
            {
                left = mid + 1;
                continue;
            }

            if (array[mid] > find)
            {
                right = mid - 1;
                continue;
            }

            return mid;
        }

        return -1;
    }

    public static int FindRecursive(int[] array, int find)
    {
        return InternalRecursive(array, find, 0, array.Length - 1);
    }

    private static int InternalRecursive(int[] array, int find, int left, int right)
    {
        if (left > right)
            return -1;

        var mid = left + (right - left) / 2;

        if (array[mid] == find)
            return mid;

        return array[mid] < find
            ? InternalRecursive(array, find, mid + 1, right)
            : InternalRecursive(array, find, left, mid - 1);
    }
}