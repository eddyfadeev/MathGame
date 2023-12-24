namespace MathGame;

internal class MathGame
{
    private readonly GameOptions _avaliableOptions = new();
    

    public void Start()
    {
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("To select an option, enter the letter and press Enter.");
        Console.WriteLine("Press any key to continue...");
        
        ShowMenu();
        char input = GetInput();

        Console.WriteLine(input);
    }

    private void ShowMenu()
    {
        Console.WriteLine("What game would you like to play?");
        Console.WriteLine("V - View Previous Games");
        DisplayGameOptions(_avaliableOptions);
        Console.WriteLine("Q - Quit the program");
    }
    
    public static int AskForInput(int optionsNumber)
    {
        while (true)
        {
            var input = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                int chosenOption = Convert.ToInt32(input);
                
                if (chosenOption >= 1 && chosenOption <= optionsNumber)
                    return chosenOption;
            }
            
            Console.Write($"Range must be between 1 and {optionsNumber}. Please try again: ");
        }
    } // end of AskForInput()
    private char GetInput()
    {
        while (true)
        {
            char convertedInput = ' ';
            var input = Console.ReadLine().Trim().ToUpper();
            if (!string.IsNullOrEmpty(input) && input.Length == 1)
            {
                // TODO: Finish this method.
            }

            return convertedInput;
        }
    }

    /**
     * <summary>
     * Displays the game options to the user defined in passed enum.
     * </summary>
     * <param name="options">Enum with the game options to display.</param>
     */
    private void DisplayGameOptions(Enum options)
    {
        // Get all name-value pairs for incoming parameter.
        Array enumData = Enum.GetValues(options.GetType());
        
        // Represent each name-value pair as a string.
        for(int i = 0; i < enumData.Length; i++)
        {
            // Convert the value to a char.
            char hotKey = Convert.ToChar(enumData.GetValue(i));
            // Display the hotkey and the name of the option.
            Console.WriteLine($"{hotKey} - {enumData.GetValue(i)}");
        }
    }
}