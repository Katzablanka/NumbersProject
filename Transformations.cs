/// <summary>
/// A static class that provides matrix transformation operations such as inversion and concatenation.
/// </summary>
public static class Transformations
{
    /// <summary>
    /// Inverts a matrix along the X-axis (horizontal flipping).
    /// </summary>
    /// <typeparam name="T">The type that implements IMatrixTransformations.</typeparam>
    /// <typeparam name="TMatrix">The type of the matrix being transformed.</typeparam>
    /// <param name="input">The input object containing the matrix to be inverted.</param>
    /// <returns>A new object with the inverted matrix.</returns>
    public static T InvertMatrixX<T, TMatrix>(T input)
        where T : IMatrixTransformations<T, TMatrix>
        where TMatrix : class
    {
        var matrix = input.GetMatrix();
        int rows = ((Array)(object)matrix).GetLength(0);
        int cols = ((Array)(object)matrix).GetLength(1);

        // Create a new empty matrix of the same type
        var inverted = (TMatrix)Activator.CreateInstance(matrix.GetType(), new object[] { rows, cols });

        // Perform the horizontal flipping
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                ((dynamic)inverted)[row, col] = ((dynamic)matrix)[row, cols - 1 - col];
            }
        }

        // Return the new object with the inverted matrix
        return input.CreateFromMatrix(inverted);
    }

    /// <summary>
    /// Inverts a matrix along the Y-axis (vertical flipping).
    /// </summary>
    /// <typeparam name="T">The type that implements IMatrixTransformations.</typeparam>
    /// <typeparam name="TMatrix">The type of the matrix being transformed.</typeparam>
    /// <param name="input">The input object containing the matrix to be inverted.</param>
    /// <returns>A new object with the inverted matrix.</returns>
    public static T InvertMatrixY<T, TMatrix>(T input)
        where T : IMatrixTransformations<T, TMatrix>
        where TMatrix : class
    {
        var matrix = input.GetMatrix();
        int rows = ((Array)(object)matrix).GetLength(0);
        int cols = ((Array)(object)matrix).GetLength(1);

        // Create a new empty matrix of the same type
        var inverted = (TMatrix)Activator.CreateInstance(matrix.GetType(), new object[] { rows, cols });

        // Perform the vertical flipping
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                ((dynamic)inverted)[row, col] = ((dynamic)matrix)[rows - 1 - row, col];
            }
        }

        // Return the new object with the inverted matrix
        return input.CreateFromMatrix(inverted);
    }

    /// <summary>
    /// Concatenates two matrices either horizontally or vertically.
    /// </summary>
    /// <typeparam name="T">The type that implements IMatrixTransformations.</typeparam>
    /// <typeparam name="TMatrix">The type of the matrices being concatenated.</typeparam>
    /// <param name="input1">The first matrix object.</param>
    /// <param name="input2">The second matrix object.</param>
    /// <param name="xAcis">True for horizontal concatenation, false for vertical concatenation.</param>
    /// <returns>A new object with the concatenated matrix.</returns>
    public static T Concat<T, TMatrix>(T input1, T input2, bool xAcis)
        where T : IMatrixTransformations<T, TMatrix>
        where TMatrix : class
    {
        var matrix1 = input1.GetMatrix();
        var matrix2 = input2.GetMatrix();

        int rows1 = ((Array)(object)matrix1).GetLength(0);
        int cols1 = ((Array)(object)matrix1).GetLength(1);
        int rows2 = ((Array)(object)matrix2).GetLength(0);
        int cols2 = ((Array)(object)matrix2).GetLength(1);

        // Determine the dimensions of the resulting matrix
        int resultCols = Math.Max(cols1, cols2);
        int resultRows = rows1 + rows2;

        if (xAcis)
        {
            resultRows = Math.Max(rows1, rows2);
            resultCols = cols1 + cols2;
        }

        // Create a new empty matrix of the same type
        var resultMatrix = (TMatrix)Activator.CreateInstance(matrix1.GetType(), new object[] { resultRows, resultCols });

        // Fill the result matrix with values from matrix1
        for (int row = 0; row < rows1; row++)
        {
            for (int col = 0; col < cols1; col++)
            {
                ((dynamic)resultMatrix)[row, col] = ((dynamic)matrix1)[row, col];
            }
        }

        // Fill the result matrix with values from matrix2
        for (int row = 0; row < rows2; row++)
        {
            for (int col = 0; col < cols2; col++)
            {
                if (xAcis)
                {
                    ((dynamic)resultMatrix)[row, col + cols1] = ((dynamic)matrix2)[row, col];
                }
                else
                {
                    ((dynamic)resultMatrix)[row + rows1, col] = ((dynamic)matrix2)[row, col];
                }
            }
        }

        // Return the new object with the concatenated matrix
        return input1.CreateFromMatrix(resultMatrix);
    }

    /// <summary>
    /// Concatenates an array of matrices sequentially, either horizontally or vertically.
    /// </summary>
    /// <typeparam name="T">The type that implements IMatrixTransformations.</typeparam>
    /// <typeparam name="TMatrix">The type of the matrices being concatenated.</typeparam>
    /// <param name="inputs">An array of input objects containing the matrices to be concatenated.</param>
    /// <param name="xAcis">True for horizontal concatenation, false for vertical concatenation.</param>
    /// <returns>A new object with the concatenated matrix.</returns>
    public static T ConcatArray<T, TMatrix>(T[] inputs, bool xAcis)
        where T : IMatrixTransformations<T, TMatrix>
        where TMatrix : class
    {
        if (inputs == null || inputs.Length == 0)
        {
            throw new ArgumentException("The input array must not be null or empty.");
        }

        // Start with the first matrix as the base
        T result = inputs[0];

        // Concatenate the rest of the matrices sequentially
        for (int i = 1; i < inputs.Length; i++)
        {
            result = Concat<T, TMatrix>(result, inputs[i], xAcis);
        }

        return result;
    }
}
