namespace MathGame;

// TODO: Use StringBuilder for AddToGameHistory method.
internal class MathGame(GameOptions gameType, int rounds, int minRange, int maxRange)
{
    private readonly Random _randomNumber = new();
    private int Score { get; set; }
    private int MinRange { get; } = minRange;
    private int MaxRange { get; } = maxRange;
    private GameOptions GameType { get; } = gameType;
    private int Rounds { get; } = rounds;
    private int CorrectAnswer { get; set; }
    private string CurrentQuestion { get; set; }
    private int UserInput { get; set; }
    private string Correctness { get; set; }

    /**
     * <summary>
     * Starts the game.
     * </summary>
     */
    public void Start()
    {
        string toStore = $"Game type: {GameType}\n" + 
                         "| Round | Question          | User     | Correct  | Result     | Score |\n" +
                         "------------------------------------------------------------------------\n";
        // Loop for the number of rounds.
        for (int i = 1; i <= Rounds; i++)
        {
            Console.Clear();
            Console.WriteLine($"Round {i} of {Rounds}");
            Console.WriteLine($"Score: {Score}");
            
            AskAQuestion(GameType, MinRange, MaxRange);
            
            UserInput = GameUtils.GetInput(-1_000_000, 1_000_000);
            
            Correctness = EvaluateAnswer(UserInput) ? "Correct!" : "Incorrect!";
            
            Console.WriteLine(Correctness);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            toStore +=
                $"| {i,5} | {CurrentQuestion,-17} | {UserInput,8} | {CorrectAnswer,8} | {Correctness,-10} | {Score,5} |\n";
        } // end of for loop.

        toStore += "------------------------------------------------------------------------";
        AddToGameHistory(toStore);
        GameUtils.TotalScore += Score;
    } // end of Start method.
    
    /**
     * <summary>
     * Calls needed method based on the passed operation and range.
     * </summary>
     * <param name="operation">Operation to generate a question for.</param>
     * <param name="fromNumber">Lower range of the question.</param>
     * <param name="toNumber">Upper range of the question.</param>
     */
    private void AskAQuestion(GameOptions operation, int fromNumber, int toNumber)
    {
        int firstNumber = _randomNumber.Next(fromNumber, toNumber + 1), 
            secondNumber = _randomNumber.Next(fromNumber, toNumber + 1);
        
        switch (operation)
        {
            case GameOptions.Addition:
                AdditionGame(firstNumber, secondNumber);
                break;
            case GameOptions.Subtraction:
                SubtractionGame(firstNumber, secondNumber);
                break;
            case GameOptions.Multiplication:
                MultiplicationGame(firstNumber, secondNumber);
                break;
            case GameOptions.Division:
                DivisionGame();
                break;
        } // end of switch statement.
    } // end of AskAQuestion method.
    
    /**
     * <summary>
     * Generates an addition question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void AdditionGame(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum + secondNum;
        CurrentQuestion = $"{firstNum} + {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of AdditionGame method.
    
    /**
     * <summary>
     * Generates a subtraction question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void SubtractionGame(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum - secondNum;
        CurrentQuestion = $"{firstNum} - {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of SubtractionGame method.
    
    /**
     * <summary>
     * Generates a multiplication question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void MultiplicationGame(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum * secondNum;
        CurrentQuestion = $"{firstNum} * {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of MultiplicationGame method.
    
    /**
     * <summary>
     * Generates a division question.
     * </summary>
     */
    private void DivisionGame()
    {
        int dividend, divisor, result;

        do
        {
            // Generate a divisor that is not 0.
            divisor = _randomNumber.Next(MinRange == 0 ? 1 : MinRange, MaxRange + 1);
            // Generate a result that is in the range. 
            result = _randomNumber.Next(MinRange, MaxRange + 1);
            // Calculate dividend by multiplying divisor and result.
            // This will ensure that division will be without remainder.
            dividend = divisor * result;
        // Loop until dividend is in the range. 
        } while (dividend > MaxRange);
        // Set question to result.
        CorrectAnswer = result;
        CurrentQuestion = $"{dividend} / {divisor} = ? ";
        Console.Write(CurrentQuestion);
    } // end of DivisionGame method.

    /**
     * <summary>
     * Evaluates the answer and increments the score if it is correct.
     * </summary>
     * <param name="answer">Answer to evaluate.</param>
     * <returns>True if answer is correct, false otherwise.</returns>
     */
    private bool EvaluateAnswer(int answer)
    {
        if (answer != CorrectAnswer) return false;
        Score++;
        return true;
    }// end of EvaluateAnswer method.

    /**
     * <summary>
     * Adds the game history to the list.
     * </summary>
     */
    private void AddToGameHistory(string gameHistory)
    {
        GameUtils.GameHistory.Add(gameHistory);
    } // end of AddToGameHistory method.
} // end of MathGame class.