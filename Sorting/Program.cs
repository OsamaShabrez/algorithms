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

int[] array = { 800, 11, 50, 771, 649, 770, 240, 9 };
PrintArray(array);
var result = SelectionSort.Iterative(ArrayCopy(array));
PrintArray(result);
result = SelectionSort.Recursive(ArrayCopy(array));
PrintArray(result);