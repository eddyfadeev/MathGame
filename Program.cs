namespace MathGame;

static class Program
{
    static void Main(string[] args)
    {
        // Default settings.
        int rounds = 5;
        int minRange = 1;
        int maxRange = 20;
        
        // Welcome message.
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("To select an option, enter the letter and press Enter.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        // Main menu.
        while (true)
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"Total Score: {GameUtils.TotalScore}");
            Console.WriteLine("V - View Previous Games");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("What game would you like to play?");
            GameUtils.DisplayGameOptions(GameUtils.AvailableOptions);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Settings");
            Console.WriteLine($"R - Rounds: {rounds}, L - Lower Range: {minRange}, U - Upper Range: {maxRange}");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Q - Quit the program");
            
            // Get input from the user.
            char input = GameUtils.GetInput(GameUtils.AvailableHotKeys);
            
            // Settings section start
            if (input.Equals('R'))
            {
                Console.WriteLine("How many rounds would you like to play?");
                Console.Write("Enter number from 1 to 20: ");
                rounds = GameUtils.GetInput(1, 20);
            }
            if (input.Equals('L'))
            {
                Console.WriteLine("How low you wanna go?");
                Console.Write("Enter number from 1 to 999: ");
                minRange = GameUtils.GetInput(1, 999);
            }
            if (input.Equals('U'))
            {
                Console.WriteLine("How high you wanna go?");
                Console.Write($"Enter number from {minRange} to 1000: ");
                maxRange = GameUtils.GetInput(minRange, 1000);
            }
            // End of settings section

            // Game section start
            if (input == 'V')
            {
                GameUtils.DisplayGameHistory();
            }
            if (input == 'Q')
            {
                Environment.Exit(0);
            }
            if (input == 'A')
            {
                new MathGame(GameOptions.Addition, rounds, minRange, maxRange).Start();
            }
            if (input == 'S')
            {
                new MathGame(GameOptions.Subtraction, rounds, minRange, maxRange).Start();
            }
            if (input == 'M')
            {
                new MathGame(GameOptions.Multiplication, rounds, minRange, maxRange).Start();
            }
            if (input == 'D')
            {
                new MathGame(GameOptions.Division, rounds, minRange, maxRange).Start();
            }
            // End of game section
            Console.Clear();
        }
    }
}