namespace Task_4;

/// <summary>
/// Entry point of the program. Demonstrates usage of the Matrix class:
/// creation, addition, multiplication, and scalar multiplication.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main method of the program. Shows examples of matrix operations.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(2, 2);
        matrix1[0, 0] = 1; matrix1[0, 1] = 2;
        matrix1[1, 0] = 3; matrix1[1, 1] = 4;

        Matrix matrix2 = new Matrix(2, 2);
        matrix2[0, 0] = 5; matrix2[0, 1] = 6;
        matrix2[1, 0] = 7; matrix2[1, 1] = 8;

        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);

        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);

        Matrix sum = matrix1 + matrix2;
        Console.WriteLine("Sum of matrices:");
        Console.WriteLine(sum);

        Matrix product = matrix1 * matrix2;
        Console.WriteLine("Matrix product:");
        Console.WriteLine(product);

        Matrix scaled = matrix1 * 2;
        Console.WriteLine("Matrix multiplied by 2:");
        Console.WriteLine(scaled);
    }
}