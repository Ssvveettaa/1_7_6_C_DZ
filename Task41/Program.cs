// Задача 41:
// Пользователь вводит с клавиатуры M чисел.
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
//  0,  7,   8, -2,  -2 –> 2
// -1, -7, 567, 89, 223 –> 3

int[] CreateArray(int size)
{
    int[] arr = new int[size];
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"Введите {i + 1}-й элемент массива: ");
        arr[i] = Convert.ToInt32(Console.ReadLine());
    }
    return arr;
}

int CounterPositiveNumbersArray(int[] arr)
{
    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > 0) count++;
    }
    return count;
}

Console.Write("Введите размер массива – M: ");
int sizeArray = Convert.ToInt32(Console.ReadLine());

// int[] array = { 0, 7, 8, -2, -2 }; // –> 2
// int[] array = { -1, -7, 567, 89, 223 }; // –> 3
int[] array = CreateArray(sizeArray);
int result = CounterPositiveNumbersArray(array);

Console.Write("В массиве: [");
Console.Write("{0}", string.Join(", ", array));
Console.WriteLine($"] чисел больше 0 –> {result}.");
