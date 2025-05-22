using System.Text;

namespace Task_4;

/// <summary>
/// Represents a two-dimensional matrix of double-precision floating-point numbers.
/// Supports basic matrix operations: addition, subtraction, multiplication,
/// scalar multiplication, equality comparison, and string representation.
/// </summary>
public class Matrix
{
    private double[,] _matrix;

    /// <summary>
    /// Gets the number of rows in the matrix.
    /// </summary>
    public int Rows { get; private set; }

    /// <summary>
    /// Gets the number of columns in the matrix.
    /// </summary>
    public int Columns { get; private set; }

    /// <summary>
    /// Initializes a matrix with the specified number of rows and columns.
    /// </summary>
    /// <param name="rows">The number of rows.</param>
    /// <param name="columns">The number of columns.</param>
    /// <exception cref="ArgumentException">Thrown when rows or columns are not positive.</exception>
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new ArgumentException("Matrix dimensions must be positive.");
        }

        Rows = rows;
        Columns = columns;
        _matrix = new double[rows, columns];
    }

    /// <summary>
    /// Initializes a matrix using a two-dimensional array.
    /// </summary>
    /// <param name="matrix">The 2D array to initialize the matrix.</param>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    public Matrix(double[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        Rows = matrix.GetLength(0);
        Columns = matrix.GetLength(1);
        _matrix = new double[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                _matrix[i, j] = matrix[i, j];
            }
        }
    }

    /// <summary>
    /// Gets or sets the element at the specified row and column.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    /// <returns>The value at the specified position.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the indices are out of bounds.</exception>
    public double this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= Rows)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Invalid row index.");
            }

            if (column < 0 || column >= Columns)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "Invalid column index.");
            }

            return _matrix[row, column];
        }
        set
        {
            if (row < 0 || row >= Rows)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Invalid row index.");
            }

            if (column < 0 || column >= Columns)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "Invalid column index.");
            }

            _matrix[row, column] = value;
        }
    }

    /// <summary>
    /// Adds two matrices of the same size.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The resulting matrix after addition.</returns>
    /// <exception cref="ArgumentException">Thrown when the matrices have different dimensions.</exception>
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new ArgumentException("Matrix sizes must match to add");
        }

        var result = new Matrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Subtracts one matrix from another.
    /// </summary>
    /// <param name="matrix1">The matrix to subtract from.</param>
    /// <param name="matrix2">The matrix to subtract.</param>
    /// <returns>The resulting matrix after subtraction.</returns>
    /// <exception cref="ArgumentException">Thrown when the matrices have different dimensions.</exception>
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new ArgumentException("Matrix sizes must match for subtraction");
        }

        var result = new Matrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Multiplies two matrices.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The resulting matrix after multiplication.</returns>
    /// <exception cref="ArgumentException">Thrown when the number of columns in the first matrix
    /// does not equal the number of rows in the second matrix.</exception>
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new ArgumentException(
                "The number of columns of the first matrix must be equal to the number of rows of the second");
        }

        var result = new Matrix(matrix1.Rows, matrix2.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Columns; j++)
            {
                double sum = 0;

                for (int k = 0; k < matrix1.Columns; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }

                result[i, j] = sum;
            }
        }

        return result;
    }

    /// <summary>
    /// Multiplies a matrix by a scalar value.
    /// </summary>
    /// <param name="matrix">The matrix to scale.</param>
    /// <param name="scalar">The scalar multiplier.</param>
    /// <returns>The resulting matrix.</returns>
    public static Matrix operator *(Matrix matrix, double scalar)
    {
        var result = new Matrix(matrix.Rows, matrix.Columns);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    /// <summary>
    /// Multiplies a scalar value by a matrix.
    /// </summary>
    /// <param name="scalar">The scalar multiplier.</param>
    /// <param name="matrix">The matrix to scale.</param>
    /// <returns>The resulting matrix.</returns>
    public static Matrix operator *(double scalar, Matrix matrix)
    {
        return matrix * scalar;
    }

    /// <summary>
    /// Determines whether two matrices are equal.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns><c>true</c> if matrices are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Matrix matrix1, Matrix matrix2)
    {
        if (ReferenceEquals(matrix1, matrix2))
        {
            return true;
        }

        if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
        {
            return false;
        }

        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            return false;
        }

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                if (Math.Abs(matrix1[i, j] - matrix2[i, j]) > 1e-10)
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether two matrices are not equal.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns><c>true</c> if matrices are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Matrix matrix1, Matrix matrix2)
    {
        return !(matrix1 == matrix2);
    }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj is Matrix matrix)
        {
            return this == matrix;
        }

        return false;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _matrix.GetHashCode();
    }

    /// <summary>
    /// Returns a string that represents the current matrix.
    /// Each row is printed on a new line, and values are separated by tabs.
    /// </summary>
    /// <returns>A string representation of the matrix.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                sb.Append($"{_matrix[i, j]:F2}\t");
            }

            sb.Append("\n");
        }

        return sb.ToString();
    }
}