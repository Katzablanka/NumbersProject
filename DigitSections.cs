/// <summary>
/// Represents the sections of a digital number display.
/// </summary>
public enum digitSections
{
  /// <summary>Top horizontal segment of the digit.</summary>
  TOP,
  /// <summary>Middle horizontal segment of the digit.</summary>
  MIDDLE,
  /// <summary>Bottom horizontal segment of the digit.</summary>
  BOTTOM,
  /// <summary>Left vertical segment of the digit.</summary>
  LEFT,
  /// <summary>Right vertical segment of the digit.</summary>
  RIGHT,
  /// <summary>Left-top vertical segment of the digit.</summary>
  LTOP,
  /// <summary>Left-bottom vertical segment of the digit.</summary>
  LBOTTOM,
  /// <summary>Right-bottom vertical segment of the digit.</summary>
  RBOTTOM,
  /// <summary>Right-top vertical segment of the digit.</summary>
  RTOP,
}

/// <summary>
/// Provides predefined coordinates for each section of a digital number display.
/// </summary>
public static class digitSectionCoordinates
{
  /// <summary>
  /// A dictionary mapping each <see cref="digitSections"/> to its respective coordinate arrays.
  /// </summary>
  public static readonly Dictionary<digitSections, int[][]> Coordinates = new Dictionary<digitSections, int[][]>
    {
        /// <summary>Coordinates for the top horizontal segment of the digit.</summary>
        { digitSections.TOP, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } } },
        /// <summary>Coordinates for the middle horizontal segment of the digit.</summary>
        { digitSections.MIDDLE, new int[][] { new int[] { 2, 1 }, new int[] { 2, 2 } } },
        /// <summary>Coordinates for the bottom horizontal segment of the digit.</summary>
        { digitSections.BOTTOM, new int[][] { new int[] { 4, 1 }, new int[] { 4, 2 } } },
        /// <summary>Coordinates for the left vertical segment of the digit.</summary>
        { digitSections.LEFT, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 } } },
        /// <summary>Coordinates for the right vertical segment of the digit.</summary>
        { digitSections.RIGHT, new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } } },
        /// <summary>Coordinates for the left-top vertical segment of the digit.</summary>
        { digitSections.LTOP, new int[][] { new int[] { 1, 0 } } },
        /// <summary>Coordinates for the left-bottom vertical segment of the digit.</summary>
        { digitSections.LBOTTOM, new int[][] { new int[] { 3, 0 } } },
        /// <summary>Coordinates for the right-bottom vertical segment of the digit.</summary>
        { digitSections.RBOTTOM, new int[][] { new int[] { 3, 3 } } },
        /// <summary>Coordinates for the right-top vertical segment of the digit.</summary>
        { digitSections.RTOP, new int[][] { new int[] { 1, 3 } } }
    };

  /// <summary>
  /// Retrieves the coordinate arrays for a specific section of a digital number display.
  /// </summary>
  /// <param name="section">The <see cref="digitSections"/> to retrieve coordinates for.</param>
  /// <returns>
  /// A 2D array of integers representing the coordinates for the specified section.
  /// </returns>
  /// <exception cref="KeyNotFoundException">
  /// Thrown if the specified <paramref name="section"/> is not found in the dictionary.
  /// </exception>
  public static int[][] getCoordinates(digitSections section)
  {
    return Coordinates[section];
  }
}
