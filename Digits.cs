/// <summary>
/// Represents the digits 0 through 9 in a digital display format.
/// </summary>
public enum Digit
{

  ZERO,

  ONE,

  TWO,

  THREE,

  FORE,

  FIVE,

  SIX,

  SEVEN,

  EIGHT,

  NINE
}

/// <summary>
/// Provides the functionality to map digits to their corresponding visual representations
/// using the <see cref="digitDisplay"/> format.
/// </summary>
public static class digitOnDisplay
{
  /// <summary>
  /// A dictionary mapping each <see cref="Digit"/> to its corresponding <see cref="digitDisplay"/>.
  /// </summary>
  private static readonly Dictionary<Digit, digitDisplay> digitToDraw = new Dictionary<Digit, digitDisplay>
    {
        { Digit.ZERO, createZero() },
        { Digit.ONE, createOne() },
        { Digit.TWO, createTwo() },
        { Digit.THREE, createThree() },
        { Digit.FORE, createFore() },
        { Digit.FIVE, createFive() },
        { Digit.SIX, createSix() },
        { Digit.SEVEN, createSeven() },
        { Digit.EIGHT, createEight() },
        { Digit.NINE, createNine() }
    };

  /// <summary>
  /// Retrieves the visual representation of a digit in the form of a <see cref="digitDisplay"/>.
  /// </summary>
  /// <param name="digit">The <see cref="Digit"/> to retrieve.</param>
  /// <returns>
  /// A <see cref="digitDisplay"/> representing the input digit.
  /// </returns>
  /// <exception cref="KeyNotFoundException">
  /// Thrown if the specified <paramref name="digit"/> is not found in the dictionary.
  /// </exception>
  public static digitDisplay GetDigit(Digit digit)
  {
    return digitToDraw[digit];
  }

  /// <summary>Creates the visual representation of the digit 0.</summary>
  private static digitDisplay createZero()
  {
    digitDisplay zero = new digitDisplay();
    zero.setTopDash();
    zero.setLeftPipe();
    zero.setRightPipe();
    zero.setBottomDash();
    return zero;
  }


  private static digitDisplay createOne()
  {
    digitDisplay one = new digitDisplay();
    one.setRightPipe();
    return one;
  }


  private static digitDisplay createTwo()
  {
    digitDisplay two = new digitDisplay();
    two.setTopDash();
    two.setRightTopPipe();
    two.setMiddleDash();
    two.setLeftBottomPipe();
    two.setBottomDash();
    return two;
  }


  private static digitDisplay createThree()
  {
    digitDisplay three = new digitDisplay();
    three.setTopDash();
    three.setRightPipe();
    three.setMiddleDash();
    three.setBottomDash();
    return three;
  }


  private static digitDisplay createFore()
  {
    digitDisplay fore = new digitDisplay();
    fore.setRightPipe();
    fore.setLeftTopPipe();
    fore.setMiddleDash();
    return fore;
  }


  private static digitDisplay createFive()
  {
    var invertedMatrix = Transformations.InvertMatrixX<digitDisplay, digitPartsSymbols[,]>(createTwo());
    return invertedMatrix;
  }


  private static digitDisplay createSix()
  {
    digitDisplay six = createFive();
    six.setLeftPipe();
    return six;
  }


  private static digitDisplay createSeven()
  {
    digitDisplay seven = createOne();
    seven.setTopDash();
    return seven;
  }


  private static digitDisplay createEight()
  {
    digitDisplay eight = createThree();
    eight.setLeftPipe();
    return eight;
  }


  private static digitDisplay createNine()
  {
    digitDisplay six = createSix();
    var transformedNumber = Transformations.InvertMatrixX<digitDisplay, digitPartsSymbols[,]>(six);
    return Transformations.InvertMatrixY<digitDisplay, digitPartsSymbols[,]>(transformedNumber);
  }
}
