using System;

public class MatrixOperations
{
    public static void Main(string[] args)
    {
        int[,] matrixA = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] matrixB = { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

        Console.WriteLine("Умножение матрицы на число:");
        int[,] multipliedMatrix = MultiplyMatrixByNumber(matrixA, 2);
        PrintMatrix(multipliedMatrix);

        Console.WriteLine("\nСложение матриц:");
        int[,] sumMatrix = AddMatrices(matrixA, matrixB);
        PrintMatrix(sumMatrix);

        Console.WriteLine("\nПроизведение матриц:");
        int[,] productMatrix = MultiplyMatrices(matrixA, matrixB);
        PrintMatrix(productMatrix);
    }

    static int[,] MultiplyMatrixByNumber(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }
        return result;
    }

    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
        {
            throw new ArgumentException("Невозможно умножить матрицы: количество столбцов первой матрицы не равно количеству строк второй матрицы.");
        }

        int[,] result = new int[rows1, cols2];
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
}