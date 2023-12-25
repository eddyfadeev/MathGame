namespace MathGame;

internal static class GameUtils
{
    internal static char[] AvailableHotKeys { get; }
    internal static GameOptions AvailableOptions { get; }
    internal static List<string> GameHistory { get; set; }
    internal static int TotalScore { get; set; }

    static GameUtils()
    {
        // Get all available hotkeys from GameOptions enum.
        AvailableHotKeys = Enum.GetValues(typeof(GameOptions))
            .Cast<GameOptions>()
            .Select(option => (char)option)
            .ToArray();

        // Get all available options from GameOptions enum.
        AvailableOptions = new GameOptions();
        // Initialize game history.
        GameHistory = new List<string>();
    }
    
    /**
    * <summary>
    * Gets input from the user, check if it exists in passed array or one of predefined chars and returns it.
    * Prints error message if input is invalid.
    * </summary>
    * <param name="options">Array of valid options.</param>
    * <returns>Valid input from the user as a char.</returns>
    */
    internal static char GetInput(char[] options)
    {
        // Loop until valid input is received.
        while (true)
        {
            // Get input from the user, trim it and convert to uppercase.
            string input = Console.ReadLine().Trim().ToUpper();
            // Try to convert input to char.
            bool parsed = char.TryParse(input, out char convertedInput);
            // Check if input exists in passed array.
            bool exists = options.Contains(convertedInput);
            
            // Check if input is valid.
            if (parsed && (exists || 
                           convertedInput == 'Q' || 
                           convertedInput == 'V' || 
                           convertedInput == 'R' || 
                           convertedInput == 'L' || 
                           convertedInput == 'U'))
            {
                return convertedInput; // Return valid input.
            } 
            
            // Print error message.
            Console.WriteLine("Invalid input. Please try again.");
        } // end of while loop.
    } // end of GetInput(char[]) method.
    
    /**
    * <summary>
    * Gets int input from the user, check if it is within the range.
    * Prints error message if input is invalid.
    * </summary>
    * <param name="lowerBond">Lower bond of valid options in form of int.</param>
    * <param name="upperBond">Upper bond of valid options in form of int.</param>
    * <returns>Valid input from the user as an int.</returns>
    */
    internal static int GetInput(int lowerBond, int upperBond)
    {
        // Loop until valid input is received.
        while (true)
        {
            // Get input from the user, trim it and convert to uppercase.
            string input = Console.ReadLine().Trim().ToUpper();
            // Try to convert input to char.
            bool parsed = int.TryParse(input, out int convertedInput);
            // Check if input is within the range.
            bool withinRange = convertedInput >= lowerBond && convertedInput <= upperBond;
            // Check if input is valid and return value.
            if (parsed && withinRange) return convertedInput; 
            
            // Print error message.
            Console.Clear();
            Console.WriteLine($"Invalid input. Please enter between {lowerBond} and {upperBond}.");
        } // end of while loop.
    } // end of GetInput(int) method.
    
    /**
     * <summary>
     * Displays the game options to the user defined in passed enum.
     * </summary>
     * <param name="options">Enum with the game options to display.</param>
     */
    internal static void DisplayGameOptions(Enum options)
    {
        // Get all name-value pairs for incoming parameter.
        Array enumData = Enum.GetValues(options.GetType());
        
        // Represent each name-value pair as a string.
        for(int i = 0; i < enumData.Length; i++)
        {
            // Display the hotkey and the name of the option.
            Console.WriteLine($"{GameUtils.AvailableHotKeys[i]} - {enumData.GetValue(i)}");
        } // end of for loop.
    } // end of DisplayGameOptions method.
}