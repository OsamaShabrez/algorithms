namespace algorithms;

// [n: no of elements; d: no of integers, k: max base i.e., ones, tens, hundreds..]
// Average case O(d*(n+k))
// Worst case O(N^2) when one element has significantly larger number of digits 
// Space complexity O(N+k) 
public static class RadixSort
{
    // assumes base if always 10
    private const int Base = 10;

    public static int[] Iterative(int[] array)
    {
        var max = array.Max();

        for (var exponent = 1; max / exponent > 0; exponent *= Base)
            CountingSort(array, exponent);

        return array;
    }

    private static void CountingSort(int[] array, int exponent)
    {
        var result = new int[array.Length];
        var count = new int[Base];

        foreach (var v in array)
            count[v / exponent % 10]++;

        for (var i = 1; i < Base; i++)
            count[i] += count[i - 1];

        for (var i = array.Length - 1; i >= 0; i--)
        {
            result[count[array[i] / exponent % 10] - 1] = array[i];
            count[array[i] / exponent % 10]--;
        }

        for (var i = 0; i < array.Length; i++)
            array[i] = result[i];
    }

    public static int[] Recursive(int[] array)
    {
        InternalRecursive(array, 1);
        return array;
    }

    private static void InternalRecursive(int[] array, int exponent)
    {
        var max = array.Max();
        if (max / exponent <= 0)
            return;
        
        CountingSort(array, exponent);
        InternalRecursive(array, exponent * Base);
    }
}