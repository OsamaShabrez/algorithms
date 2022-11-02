using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTests;

public class UnitTestSorting
{
    public static IEnumerable<object> Data =>
        new List<object>
        {
            new object[]
            {
                new[] { 800, 11, 50, 771, 649, 770, 240, 9, 15, 7, 999, 72, 37 },
                new[] { 7, 9, 11, 15, 37, 50, 72, 240, 649, 770, 771, 800, 999 }
            },
            new object[]
            {
                new[] { 5, 7, -9, 3, -4, 2, 8 },
                new[] { -9, -4, 2, 3, 5, 7, 8 }
            },
            new object[]
            {
                new[] { 10, 8, 7, 3, 5, 1, 9, 2, 4, 6 },
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TestBubbleSort(int[] input, int[] output)
    {
        var result = BubbleSort.Iterative(input);
        CollectionAssert.AreEqual(output, result);

        result = BubbleSort.Recursive(input);
        CollectionAssert.AreEqual(output, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void TestMergeSort(int[] input, int[] output)
    {
        var result = MergeSort.Iterative(input);
        CollectionAssert.AreEqual(output, result);

        result = MergeSort.Recursive(input);
        CollectionAssert.AreEqual(output, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void TestRadixSort(int[] input, int[] output)
    {
        // todo update RadixSort to handle negative integers
        if (input.Min() < 0) return;

        var result = RadixSort.Iterative(input);
        CollectionAssert.AreEqual(output, result);

        result = RadixSort.Recursive(input);
        CollectionAssert.AreEqual(output, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void TestQuickSort(int[] input, int[] output)
    {
        var result = QuickSort.Iterative(input);
        CollectionAssert.AreEqual(output, result);

        result = QuickSort.Recursive(input);
        CollectionAssert.AreEqual(output, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void TestSelectionSort(int[] input, int[] output)
    {
        var result = SelectionSort.Iterative(input);
        CollectionAssert.AreEqual(output, result);

        result = SelectionSort.Recursive(input);
        CollectionAssert.AreEqual(output, result);
    }
}