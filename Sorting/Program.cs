// See https://aka.ms/new-console-template for more information

using algorithms;

int[] ArrayCopy(int[] array)
{
    var newArray = new int[array.Length];
    Array.Copy(array, 0, newArray, 0, array.Length);
    return newArray;
}

void PrintArray(IEnumerable<int> array)
{
    foreach (var i in array)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}

int[] array = { 800, 11, 50, 771, 649, 770, 240, 9, 15, 7, 999, 72, 37 };
int[] test = { 5, 7, -9, 3, -4, 2, 8 };//{10, 8, 7, 3, 5, 1, 9, 2, 4, 6};
PrintArray(array);
var result = MergeSort.Iterative(ArrayCopy(test));
PrintArray(result);
result = MergeSort.Iterative(ArrayCopy(array));
PrintArray(result);
result = MergeSort.Recursive(ArrayCopy(array));
PrintArray(result);