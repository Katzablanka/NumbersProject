using System;
using System.Runtime.InteropServices;

/// <summary>
/// Represents the coordinate system for a number, allowing for various matrix transformations such as inversion along different axes.
/// </summary>
public class NumberCoordsField
{
    /// <summary>
    /// The number of rows in the original number matrix.
    /// </summary>
    private int inputRows;

    /// <summary>
    /// The number of columns in the original number matrix.
    /// </summary>
    private int inputCols;

    /// <summary>
    /// Indicates whether the number has been inverted along the X-axis.
    /// </summary>
    private bool xInverted;

    /// <summary>
    /// Indicates whether the number has been inverted along the Y-axis.
    /// </summary>
    private bool yInverted;

    /// <summary>
    /// Indicates whether the number has been inverted along both the X and Y axes.
    /// </summary>
    private bool xyInverted;

    /// <summary>
    /// The initial number object containing the original matrix.
    /// </summary>
    private NumberOperations initialNumber;

    /// <summary>
    /// The coordinate system matrix representing the number and its transformations.
    /// </summary>
    private digitPartsSymbols[,] coordSystem;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberCoordsField"/> class with the specified number.
    /// </summary>
    /// <param name="inputNumber">The <see cref="NumberOperations"/> object representing the original number.</param>
    public NumberCoordsField(NumberOperations inputNumber)
    {
        // Retrieve the dimensions of the original number matrix
        inputRows = inputNumber.GetMatrix().GetLength(0);
        inputCols = inputNumber.GetMatrix().GetLength(1);
        initialNumber = inputNumber;

        // Create the initial coordinate system matrix
        coordSystem = CreateCoordSystem();

        // Initialize inversion flags to false
        xInverted = false;
        yInverted = false;
        xyInverted = false;
    }

    /// <summary>
    /// Creates the initial coordinate system matrix based on the original number matrix.
    /// </summary>
    /// <returns>A matrix of type <see cref="digitPartsSymbols[,]"/> representing the coordinate system.</returns>
    public digitPartsSymbols[,] CreateCoordSystem()
    {
        // Initialize a new matrix with expanded dimensions to accommodate transformations
        digitPartsSymbols[,] coordSystemMatrix = new digitPartsSymbols[inputRows * 2 + 1, inputCols * 2 + 1];

        // Iterate through each cell to populate the coordinate system
        for (int row = 0; row < inputRows * 2 + 1; row++)
        {
            for (int col = 0; col < inputCols * 2 + 1; col++)
            {
                // Default to SPACE symbol
                coordSystemMatrix[row, col] = digitPartsSymbols.SPACE;

                if (row < inputRows && col < inputCols)
                {
                    // Copy the symbol from the original number matrix
                    coordSystemMatrix[row, col] = initialNumber.GetMatrix()[row, col];
                }
                else if (row == inputRows)
                {
                    // Add a DASH symbol along the central horizontal axis
                    coordSystemMatrix[row, col] = digitPartsSymbols.DASH;
                }
                else if (col == inputCols)
                {
                    // Add a PIPE symbol along the central vertical axis
                    coordSystemMatrix[row, col] = digitPartsSymbols.PIPE;
                }
            }
        }

        return coordSystemMatrix;
    }

    /// <summary>
    /// Gets a value indicating whether the number has been inverted along the X-axis.
    /// </summary>
    public bool XInverted => xInverted;

    /// <summary>
    /// Gets a value indicating whether the number has been inverted along the Y-axis.
    /// </summary>
    public bool YInverted => yInverted;

    /// <summary>
    /// Gets a value indicating whether the number has been inverted along both the X and Y axes.
    /// </summary>
    public bool XYInverted => xyInverted;

    /// <summary>
    /// Inverts the coordinate system matrix along the X-axis (horizontal flip).
    /// </summary>
    public void fillXinverion()
    {
        // Invert the original number matrix along the X-axis
        NumberOperations invertedNumberX = Transformations.InvertMatrixX<NumberOperations, digitPartsSymbols[,]>(initialNumber);

        // Apply the inverted matrix to the right side of the coordinate system
        for (int row = 0; row < inputRows; row++)
        {
            for (int col = inputCols + 1; col < coordSystem.GetLength(1); col++)
            {
                // Calculate the corresponding column in the inverted matrix
                coordSystem[row, col] = invertedNumberX.GetMatrix()[row, col - inputCols - 1];
            }
        }

        // Update the inversion flag
        xInverted = true;
    }

    /// <summary>
    /// Inverts the coordinate system matrix along the Y-axis (vertical flip).
    /// </summary>
    public void fillYinverion()
    {
        // Invert the original number matrix along the Y-axis
        NumberOperations invertedNumberY = Transformations.InvertMatrixY<NumberOperations, digitPartsSymbols[,]>(initialNumber);

        // Apply the inverted matrix to the bottom side of the coordinate system
        for (int row = inputRows + 1; row < coordSystem.GetLength(0); row++)
        {
            for (int col = 0; col < inputCols; col++)
            {
                // Calculate the corresponding row in the inverted matrix
                coordSystem[row, col] = invertedNumberY.GetMatrix()[row - inputRows - 1, col];
            }
        }

        // Update the inversion flag
        yInverted = true;
    }

    /// <summary>
    /// Inverts the coordinate system matrix along both the X and Y axes (horizontal and vertical flip).
    /// </summary>
    public void fillXYinverion()
    {
        // Invert the original number matrix along the Y-axis first
        NumberOperations invertedNumberY = Transformations.InvertMatrixY<NumberOperations, digitPartsSymbols[,]>(initialNumber);

        // Then invert the resulting matrix along the X-axis
        NumberOperations invertedNumberXY = Transformations.InvertMatrixX<NumberOperations, digitPartsSymbols[,]>(invertedNumberY);

        // Apply the doubly inverted matrix to the bottom-right quadrant of the coordinate system
        for (int row = inputRows + 1; row < coordSystem.GetLength(0); row++)
        {
            for (int col = inputCols + 1; col < coordSystem.GetLength(1); col++)
            {
                // Calculate the corresponding row and column in the doubly inverted matrix
                coordSystem[row, col] = invertedNumberXY.GetMatrix()[row - inputRows - 1, col - inputCols - 1];
            }
        }

        // Update the inversion flag
        xyInverted = true;
    }

    /// <summary>
    /// Prints the current state of the coordinate system matrix to the console.
    /// </summary>
    public void PrintCoordfield()
    {
        for (int i = 0; i < coordSystem.GetLength(0); i++)
        {
            for (int j = 0; j < coordSystem.GetLength(1); j++)
            {
                // Print each symbol in the matrix
                Console.Write(coordSystem[i, j].getSymbol());
            }
            // Move to the next line after each row
            Console.WriteLine();
        }
    }
}
