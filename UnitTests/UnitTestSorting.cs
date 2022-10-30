using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTests;

public class UnitTestSorting
{
    private readonly int[] _t1 = { 800, 11, 50, 771, 649, 770, 240, 9, 15, 7, 999, 72, 37 };
    private readonly int[] _r1 = { 7, 9, 11, 15, 37, 50, 72, 240, 649, 770, 771, 800, 999 };

    private readonly int[] _t2 = { 5, 7, -9, 3, -4, 2, 8 };
    private readonly int[] _r2 = { -9, -4, 2, 3, 5, 7, 8 };

    private readonly int[] _t3 = { 10, 8, 7, 3, 5, 1, 9, 2, 4, 6 };
    private readonly int[] _r3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    private static int[] ArrayCopy(int[] array)
    {
        var newArray = new int[array.Length];
        Array.Copy(array, 0, newArray, 0, array.Length);
        return newArray;
    }

    [Fact]
    public void TestBubbleSort()
    {
        var result = BubbleSort.Iterative(ArrayCopy(_t1));
        CollectionAssert.AreEqual(_r1, result);

        result = BubbleSort.Recursive(ArrayCopy(_t2));
        CollectionAssert.AreEqual(_r2, result);

        result = BubbleSort.Recursive(ArrayCopy(_t3));
        CollectionAssert.AreEqual(_r3, result);
    }
    
    [Fact]
    public void TestMergeSort()
    {
        var result = MergeSort.Iterative(ArrayCopy(_t1));
        CollectionAssert.AreEqual(_r1, result);

        result = MergeSort.Recursive(ArrayCopy(_t2));
        CollectionAssert.AreEqual(_r2, result);

        result = MergeSort.Recursive(ArrayCopy(_t3));
        CollectionAssert.AreEqual(_r3, result);
    }

    [Fact]
    public void TestSelectionSort()
    {
        var result = SelectionSort.Iterative(ArrayCopy(_t1));
        CollectionAssert.AreEqual(_r1, result);

        result = SelectionSort.Recursive(ArrayCopy(_t2));
        CollectionAssert.AreEqual(_r2, result);

        result = SelectionSort.Recursive(ArrayCopy(_t3));
        CollectionAssert.AreEqual(_r3, result);
    }
}