/// <summary>
/// Represents a visual display for digits, using a matrix of symbols to define the structure of each digit.
/// Implements the <see cref="IMatrixTransformations{T, TMatrix}"/> interface for matrix-based transformations.
/// </summary>
public class digitDisplay : IMatrixTransformations<digitDisplay, digitPartsSymbols[,]>
{
  /// <summary>
  /// The 2D array representing the visual layout of the digit using <see cref="digitPartsSymbols"/>.
  /// </summary>
  public digitPartsSymbols[,] lineState { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="digitDisplay"/> class.
  /// The display matrix is set to 5 rows and 4 columns, initialized with spaces.
  /// </summary>
  public digitDisplay()
  {
    lineState = new digitPartsSymbols[5, 4];
    initializeArray();
  }

  /// <summary>
  /// Gets the current matrix representation of the digit.
  /// </summary>
  public digitPartsSymbols[,] GetMatrix() => lineState;

  /// <summary>
  /// Sets the matrix representation of the digit.
  /// </summary>
  public void SetMatrix(digitPartsSymbols[,] matrix) => lineState = matrix;

  /// <summary>
  /// Creates a new instance of <see cref="digitDisplay"/> using the provided matrix.
  /// </summary>
  public digitDisplay CreateFromMatrix(digitPartsSymbols[,] matrix) => new digitDisplay { lineState = matrix };

  private void initializeArray()
  {
    for (int row = 0; row < lineState.GetLength(0); row++)
      for (int col = 0; col < lineState.GetLength(1); col++)
        lineState[row, col] = digitPartsSymbols.SPACE;
  }

  /// <summary>
  /// Sets a specific cell in the matrix to a given symbol.
  /// </summary>
  /// <exception cref="IndexOutOfRangeException">Thrown if the row or column is out of bounds.</exception>
  public void set(int row, int col, digitPartsSymbols value)
  {
    if (row < 0 || row >= 5 || col < 0 || col >= 4)
      throw new IndexOutOfRangeException("Row or column out of range");

    lineState[row, col] = value;
  }

  public void setPositions(int[][] positions, digitPartsSymbols value)
  {
    foreach (var pos in positions)
      set(pos[0], pos[1], value);
  }

  /// <summary>
  /// Sets a specific section of the digit (e.g., top, middle, bottom) to a given symbol.
  /// </summary>
  public void setSection(digitSections section, digitPartsSymbols symbol)
  {
    var coordinates = digitSectionCoordinates.getCoordinates(section);
    setPositions(coordinates, symbol);
  }

  /// <summary>Sets the top section of the digit to a dash.</summary>
  public void setTopDash() => setSection(digitSections.TOP, digitPartsSymbols.DASH);

  /// <summary>Sets the middle section of the digit to a dash.</summary>
  public void setMiddleDash() => setSection(digitSections.MIDDLE, digitPartsSymbols.DASH);

  /// <summary>Sets the bottom section of the digit to a dash.</summary>
  public void setBottomDash() => setSection(digitSections.BOTTOM, digitPartsSymbols.DASH);

  /// <summary>Sets the right vertical pipes of the digit.</summary>
  public void setRightPipe()
  {
    setSection(digitSections.RTOP, digitPartsSymbols.PIPE);
    setSection(digitSections.RBOTTOM, digitPartsSymbols.PIPE);
  }

  /// <summary>Sets the left vertical pipes of the digit.</summary>
  public void setLeftPipe()
  {
    setSection(digitSections.LTOP, digitPartsSymbols.PIPE);
    setSection(digitSections.LBOTTOM, digitPartsSymbols.PIPE);
  }

  /// <summary>Sets the top-right pipe of the digit.</summary>
  public void setRightTopPipe() => setSection(digitSections.RTOP, digitPartsSymbols.PIPE);

  /// <summary>Sets the top-left pipe of the digit.</summary>
  public void setLeftTopPipe() => setSection(digitSections.LTOP, digitPartsSymbols.PIPE);

  /// <summary>Sets the bottom-right pipe of the digit.</summary>
  public void setRightBottomPipe() => setSection(digitSections.RBOTTOM, digitPartsSymbols.PIPE);

  /// <summary>Sets the bottom-left pipe of the digit.</summary>
  public void setLeftBottomPipe() => setSection(digitSections.LBOTTOM, digitPartsSymbols.PIPE);

  /// <summary>
  /// Prints the digit display to the console.
  /// </summary>
  public void printDisplayDigit()
  {
    for (int row = 0; row < lineState.GetLength(0); row++)
    {
      for (int col = 0; col < lineState.GetLength(1); col++)
        Console.Write(lineState[row, col].getSymbol());

      Console.WriteLine();
    }
  }

  /// <summary>
  /// Gets the symbol at a specific cell in the matrix.
  /// </summary>
  /// <exception cref="IndexOutOfRangeException">Thrown if the row or column is out of bounds.</exception>
  public digitPartsSymbols Get(int row, int col)
  {
    if (row < 0 || row >= 5 || col < 0 || col >= 4)
      throw new IndexOutOfRangeException("Row or column out of range");

    return lineState[row, col];
  }
}
