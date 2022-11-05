using Searching;
using Xunit;

namespace UnitTests;

public class UnitTestSearching
{
    public static IEnumerable<object> Data =>
        new List<object>
        {
            new object[]
            {
                new[] { 7, 9, 11, 15, 37, 50, 72, 240, 649, 770, 771, 800, 999 },
                770,
                9
            },

            new object[]
            {
                new[] { -9, -4, 2, 3, 5, 7, 8 },
                -4,
                1
            },
            new object[]
            {
                new[] { 6, 19, 21, 25, 39, 52, 177, 222, 449, 670, 779, 890, 909 },
                420,
                -1
            },
            new object[]
            {
                new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                5,
                5
            }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TestBinarySearch(int[] input, int find, int resultIdx)
    {
        var result = BinarySearch.FindIterative(input, find);
        Assert.Equal(result, resultIdx);

        result = BinarySearch.FindRecursive(input, find);
        Assert.Equal(result, resultIdx);
    }
}