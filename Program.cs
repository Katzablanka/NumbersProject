/// <summary>
/// Main class for the program that processes user input and displays a visual representation of numbers.
/// </summary>
public class NumberProgram
{
  /// <summary>
  /// Main entry point for the application.
  /// </summary>
  /// <param name="args">Command-line arguments (not used in this application).</param>
  static void Main(string[] args)
  {
    // Initialize variables for user input and number validation
    string userInput = "0000";
    int number = 0;

    // Try parsing the initial user input
    bool inputIsNumber = int.TryParse(userInput, out number);

    // Loop to ensure the user enters a valid number between 1 and 4 digits
    do
    {
      Console.WriteLine("The amount of digits should be between 1 and 4");
      Console.WriteLine("Enter your number:");
      userInput = Console.ReadLine() ?? "0000"; // Default to "0000" if input is null
      inputIsNumber = int.TryParse(userInput, out number);
    } while (userInput.Length > 4 || !inputIsNumber);

    // If the input is less than 4 digits, pad it with leading zeros
    if (userInput.Length < 4)
    {
      int fillerAmount = 4 - userInput.Length;
      string filler = String.Concat(Enumerable.Repeat("0", fillerAmount));
      userInput = string.Concat(filler, userInput);
    }

    // Convert input string to an array of integers
    int[] inputDigits = userInput.Select(e => e - '0').ToArray();
    var digitsInNumber = new List<digitDisplay>();

    // Process each digit and convert it into a visual representation
    foreach (var singleDigit in inputDigits)
    {
      // Check if the digit is defined in the Digit enum
      if (Enum.IsDefined(typeof(Digit), singleDigit))
      {
        var enteredDigit = digitOnDisplay.GetDigit((Digit)singleDigit);
        if (enteredDigit != null)
        {
          digitsInNumber.Add(enteredDigit); // Add the digit to the list if valid
        }
        else
        {
          Console.WriteLine("Invalid digit display.");
        }
      }
      else
      {
        Console.WriteLine($"Digit {singleDigit} is not defined in the Digit enum.");
      }
    }

    // If there are valid digits, display the number and offer inversion options
    if (digitsInNumber.Count > 0)
    {
      NumberOperations originalNumber = new NumberOperations(digitsInNumber.ToArray());
      NumberCoordsField coordsField = new NumberCoordsField(originalNumber);
      coordsField.PrintCoordfield();

      string userInputAction = "0000";
      while (userInputAction != "q")
      {
        Console.WriteLine("What's next?");
        Console.WriteLine("Press 'i' to invert");
        Console.WriteLine("Press 'q' to exit");
        userInputAction = Console.ReadLine() ?? "0000";

        if (userInputAction == "i")
        {
          // Submenu for choosing inversion options
          while (userInputAction != "q")
          {
            Console.WriteLine("Which inversion should it be?");
            Console.WriteLine("Press 'x' to invert the number along the x-axis");
            Console.WriteLine("Press 'y' to invert the number along the y-axis");
            Console.WriteLine("Press 'xy' to invert the number along both axes");
            Console.WriteLine("Press 'q' to exit");
            userInputAction = Console.ReadLine()?.ToLower() ?? "0000";

            switch (userInputAction)
            {
              case "q":
                CloseApplication();
                break;
              case "x":
                if (!coordsField.XInverted) { coordsField.fillXinverion(); }
                coordsField.PrintCoordfield();
                break;
              case "y":
                if (!coordsField.YInverted) { coordsField.fillYinverion(); }
                coordsField.PrintCoordfield();
                break;
              case "xy":
                if (!coordsField.XYInverted) { coordsField.fillXYinverion(); }
                coordsField.PrintCoordfield();
                break;
              default:
                Console.WriteLine("Invalid input, please try again!");
                break;
            }
          }
        }
      }
    }
    else
    {
      Console.WriteLine("No valid digits to display.");
    }
  }

  /// <summary>
  /// Closes the application gracefully.
  /// </summary>
  static void CloseApplication()
  {
    Console.WriteLine("Closing application...");
    Environment.Exit(0); // Exit with code 0 (success)
  }
}
