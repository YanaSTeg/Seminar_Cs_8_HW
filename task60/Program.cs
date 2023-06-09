// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int[] UniquesNumbArray(int size, int leftRange, int rightRange)
{
    int[] UniqueArr = new int[size];
    int count = 0;
    Random rand = new Random();
    while (count < UniqueArr.Length)
    {
        bool NumbRepeat = false;
        int a = rand.Next(leftRange, rightRange + 1);
        for (int i = 0; i < UniqueArr.Length; i++)
        {
            if (UniqueArr[i] == a)
            {
                NumbRepeat = true;
                break;
            }
        }
        if (NumbRepeat != true)
        {
            UniqueArr[count] = a;
            count++;
        }
    }
    count = 0;
    return UniqueArr;
}

int[,,] UniquesMatrixNumb(int row, int col, int vol, int leftRange, int rightRange)
{
    int[,,] matrix = new int[row, col, vol];
    int count = 0;
    int[] uniqueArr = UniquesNumbArray(row * col * vol, leftRange, rightRange);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = uniqueArr[count];
                count++;
            }
        }

    }
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                System.Console.Write($"{matrix[i, j, k]}");
                System.Console.Write($"{(i, j, k)}");
                System.Console.Write("\t");
            }
            System.Console.WriteLine();
        }
    }
}
int[,,] matrix = UniquesMatrixNumb(ReadInt("Введите количество строк: "), ReadInt("Введите количество столбцов: "),ReadInt("Введите ширину матрицы: "), 0, 99);
System.Console.WriteLine();
PrintMatrix(matrix);
System.Console.WriteLine();
