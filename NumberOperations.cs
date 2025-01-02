/// <summary>
/// Represents a number consisting of multiple digit displays, 
/// providing functionality for manipulating and retrieving the associated matrix.
/// </summary>
public class NumberOperations : IMatrixTransformations<NumberOperations, digitPartsSymbols[,]>
{
    /// <summary>
    /// Array of digit displays representing the digits of the number.
    /// </summary>
    private digitDisplay[] digitsArray;

    /// <summary>
    /// Matrix representation of the entire number.
    /// </summary>
    private digitPartsSymbols[,] number;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperations"/> class 
    /// with an array of digit displays.
    /// </summary>
    /// <param name="arrayInputDigits">The array of digit displays representing the digits.</param>
    /// <exception cref="ArgumentException">Thrown when the input array is null or empty.</exception>
    public NumberOperations(digitDisplay[] arrayInputDigits)
    {
        if (arrayInputDigits == null || arrayInputDigits.Length == 0)
        {
            throw new ArgumentException("Input digits array cannot be null or empty.");
        }

        this.digitsArray = arrayInputDigits;

        // Build the concatenated number matrix
        BuildNumberMatrix();
    }

    /// <summary>
    /// Builds the matrix representation of the concatenated digits.
    /// </summary>
    private void BuildNumberMatrix()
    {
        // Concatenate all digit matrices horizontally
        var resultMatrix = Transformations.ConcatArray<digitDisplay, digitPartsSymbols[,]>(digitsArray, true);

        // Set the resulting concatenated matrix as the number
        this.number = resultMatrix.lineState;
    }

    /// <summary>
    /// Prints the number matrix to the console.
    /// </summary>
    public void PrintNumber()
    {
        for (int i = 0; i < number.GetLength(0); i++)
        {
            for (int j = 0; j < number.GetLength(1); j++)
            {
                // Print the symbol of each element in the matrix
                Console.Write(number[i, j].getSymbol());
            }
            Console.WriteLine();
        }
    }

    // Implementation of IMatrixTransformations

    /// <summary>
    /// Retrieves the matrix representation of the number.
    /// </summary>
    /// <returns>The matrix of type <see cref="digitPartsSymbols[,]"/>.</returns>
    public digitPartsSymbols[,] GetMatrix()
    {
        return number;
    }

    /// <summary>
    /// Updates the matrix representation of the number.
    /// </summary>
    /// <param name="matrix">The new matrix to set.</param>
    public void SetMatrix(digitPartsSymbols[,] matrix)
    {
        this.number = matrix;
    }

    /// <summary>
    /// Creates a new instance of <see cref="NumberOperations"/> from a given matrix.
    /// </summary>
    /// <param name="matrix">The matrix to convert into a <see cref="NumberOperations"/> object.</param>
    /// <returns>A new instance of <see cref="NumberOperations"/>.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the input matrix is null, empty, or cannot be converted to a valid digit array.
    /// </exception>
    public NumberOperations CreateFromMatrix(digitPartsSymbols[,] matrix)
    {
        // Validate the input matrix
        if (matrix == null || ((Array)(object)matrix).GetLength(0) == 0 || ((Array)(object)matrix).GetLength(1) == 0)
        {
            throw new ArgumentException("Input matrix cannot be null or empty.");
        }

        // Convert the matrix to an array of digit displays
        var digitArray = ConvertMatrixToDigitArray(matrix);

        // Validate the resulting digit array
        if (digitArray == null || digitArray.Length == 0)
        {
            throw new ArgumentException("Converted digit array cannot be null or empty.");
        }

        // Create and return the new NumberOperations object
        return new NumberOperations(digitArray) { number = matrix };
    }

    /// <summary>
    /// Converts a matrix representation of a number into an array of digit displays.
    /// </summary>
    /// <param name="matrix">The matrix to convert.</param>
    /// <returns>An array of digit displays.</returns>
    private digitDisplay[] ConvertMatrixToDigitArray(digitPartsSymbols[,] matrix)
    {
        int rows = ((Array)(object)matrix).GetLength(0);
        int cols = ((Array)(object)matrix).GetLength(1);

        // Create a list to store the digit displays
        var digitArray = new List<digitDisplay>();

        // Map the matrix rows and columns to digit displays
        for (int row = 0; row < rows; row++)
        {
            var digit = new digitDisplay();

            for (int col = 0; col < cols; col++)
            {
                var symbol = (digitPartsSymbols)((dynamic)matrix)[row, col];
                // Map symbols to digit display properties
                if (symbol == digitPartsSymbols.DASH)
                    digit.setTopDash();
                else if (symbol == digitPartsSymbols.PIPE)
                    digit.setRightPipe();
            }

            digitArray.Add(digit);
        }

        return digitArray.ToArray();
    }

    /// <summary>
    /// Retrieves the matrix representation of the number.
    /// </summary>
    /// <returns>The matrix of type <see cref="digitPartsSymbols[,]"/>.</returns>
    public digitPartsSymbols[,] getNumber()
    {
        return number;
    }
}
