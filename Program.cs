/*Задача 41:Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223 -> 4 */

Console.Clear();
Console.WriteLine("Вводите числа через запятую: "); //Числа необходимо вводить через запятую!
string? input = Console.ReadLine();
int[] numbers = ParseStringToArray(input);
PrintArray(numbers);


int Comparison(int[] Numbers)
{
    int count = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (Numbers[i] > 0) count += 1;
    }
    return count;
}

Console.WriteLine($"Количество чисел больше нуля -> {Comparison(numbers)} ");

int[] ParseStringToArray(string input)
{
    int countNumbers = GetCountNumbersInString(input);
    int[] numbers = new int[countNumbers];
    int indexNumber = 0;
    string substring = string.Empty;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] != ',')
        {
            substring += input[i];
        }
        else
        {
            numbers[indexNumber] = Convert.ToInt32(substring);
            indexNumber++;
            substring = string.Empty;
        }
    }
    if (input[input.Length - 1] != ',')
        numbers[indexNumber] = Convert.ToInt32(substring);
    return numbers;
}
int GetCountNumbersInString(string input)
{
    int count;
    if (input[input.Length - 1] == ',')
        count = 0;
    else
        count = 1;

    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == ',')
            count++;
    }
    return count;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}


//=============================================================================================================================================================================================================================


/* Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)*/


Console.Clear();
Console.WriteLine($"\nНаходим точку пересечения двух прямых \n");

double[,] level = new double[2, 2];
double[] intersectionPoint = new double[2];

void InputCoefficients()
{
    for (int i = 0; i < level.GetLength(0); i++)
    {
        Console.Write($"Введите значение {i + 1}-й прямой (y = k * x + b):\n");
        for (int j = 0; j < level.GetLength(1); j++)
        {
            if (j == 0) Console.Write($"Введите значение k: ");
            else Console.Write($"Введите значение b: ");
            level[i, j] = Convert.ToInt32(Console.ReadLine());
        }
    }
}

double[] Decision(double[,] level)
{
    intersectionPoint[0] = (level[1, 1] - level[0, 1]) / (level[0, 0] - level[1, 0]);
    intersectionPoint[1] = intersectionPoint[0] * level[0, 0] + level[0, 1];
    return intersectionPoint;
}

void OutputResponse(double[,] level)
{
    if (level[0, 0] == level[1, 0] && level[0, 1] == level[1, 1])
    {
        Console.Write($"\nПрямые совпадают");
    }
    else
    if (level[0, 0] == level[1, 0] && level[0, 1] != level[1, 1])
    {
        Console.Write($"\nПрямые параллельны");
    }
    else
    {
        Decision(level);
        Console.Write($"\nТочка пересечения прямых: ({intersectionPoint[0]}, {intersectionPoint[1]})");
    }
}

InputCoefficients();
OutputResponse(level);



