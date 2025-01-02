/// <summary>
/// Represents the basic symbols used to construct digit displays.
/// </summary>
public enum digitPartsSymbols
{
  /// <summary>Represents a vertical line or pipe symbol (|).</summary>
  PIPE,

  /// <summary>Represents a horizontal line or dash symbol (-).</summary>
  DASH,

  /// <summary>Represents an empty space symbol ( ).</summary>
  SPACE
}

/// <summary>
/// Provides utility methods and mappings for the <see cref="digitPartsSymbols"/> enum.
/// </summary>
public static class digitParts
{
  /// <summary>
  /// Maps each <see cref="digitPartsSymbols"/> to its corresponding string representation.
  /// </summary>
  public static readonly Dictionary<digitPartsSymbols, string> Symbols = new Dictionary<digitPartsSymbols, string>
    {
        { digitPartsSymbols.PIPE, "|" },
        { digitPartsSymbols.DASH, "-" },
        { digitPartsSymbols.SPACE, " " }
    };

  /// <summary>
  /// Gets the string representation of a <see cref="digitPartsSymbols"/>.
  /// </summary>
  /// <param name="part">The <see cref="digitPartsSymbols"/> value for which to retrieve the string representation.</param>
  /// <returns>A string representation of the provided <paramref name="part"/>.</returns>
  /// <exception cref="KeyNotFoundException">
  /// Thrown if the specified <paramref name="part"/> is not found in the <see cref="Symbols"/> dictionary.
  /// </exception>
  public static string getSymbol(this digitPartsSymbols part)
  {
    return Symbols[part];
  }
}
