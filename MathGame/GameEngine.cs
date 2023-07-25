using MathGame.Models;
namespace MathGame
{
    internal class GameEngine
    {   
        internal void StartGame (GameType operation , GameDifficulty difficulty, char operationSymbol) {
            var  scoredAnswers = 0;

            for(var round = 0; round < 5; round++)
            {

                RenderOperation( round , operationSymbol,  operation, difficulty, ref scoredAnswers);

                if(round == 4) {
                    // pending implmentation
                    Console.WriteLine("Final Score: {0}", scoredAnswers);
                    Console.ReadKey();
                  //  Helpers.AddToHistory(gameScore, operation, difficulty);
                }
            }    
        }

        /// <summary>
        /// Will receive the number and will do a a mathematical operation
        /// </summary>
        /// <param name="numbers">Tuple of a given random numbers</param>
        /// <param name="operation">Enum for type of opeation</param>
        /// <returns></returns>
        private static int DoOperation ((int FirstInt, int SecondInt) numbers, GameType operation)
        {
            int result = 0;
            switch (operation)
            {
                case GameType.Addition:
                    result = numbers.FirstInt + numbers.SecondInt;
                    break;
                case GameType.Substraction:
                    result = numbers.FirstInt - numbers.SecondInt;
                    break;
                case GameType.Multiplication:
                    result = numbers.FirstInt * numbers.SecondInt;
                    break;
                case GameType.Division:
                    result = numbers.FirstInt / numbers.SecondInt;
                    break;
                
            }   

            return result;
            
        }
        /// <summary>
        /// Will create a tuple of two random number that depending of the difficulty
        /// will be a bigger or smaller number
        /// </summary>
        /// <param name="difficulty"> enum </param>
        /// <param name="operation"> enum </param>
        /// <returns> tuple of integers </returns>
        private static (int , int) GetRamdomNum(GameDifficulty difficulty, GameType operation)
        {
            var random = new Random();
            int numberSize = 9;

            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    numberSize = operation == GameType.Division ? 99: 9;
                    break;
                case GameDifficulty.Medium:
                    numberSize = operation == GameType.Division ? 999:99;
                    break;
                case GameDifficulty.Hard:
                    numberSize = operation == GameType.Division ? 9999:999;
                    break;
            }

            var firstNumber = random.Next(1, numberSize);
            var secondNumber = random.Next(1, numberSize);

            if (operation == GameType.Division)
            {
                while (firstNumber % secondNumber != 0)
                {
                     firstNumber = random.Next(1, numberSize);
                     secondNumber = random.Next(1, numberSize);   
                }  
            }
            
            return (firstNumber, secondNumber);
        }

        /// <summary>
        /// will render the opeation on the screen and call the the private functions: GetRandomNum and DoOperation
        /// once call will check if the answer given is correct and comparate with operation done by doOperation.
        /// in case is correct will add +1 to correctAnswers which is passed by ref by the parent funtion StartGame.
        /// </summary>
        /// <param name="round"> games round</param>
        /// <param name="symbolOperator"> operator symbol </param>
        /// <param name="operation"> enum </param>
        /// <param name="difficulty"> enum </param>
        /// <param name="correctAnswers"> in ref from startGame funtion</param>
        internal static void RenderOperation( int round, char symbolOperator, GameType operation, GameDifficulty difficulty, ref int correctAnswers)
        {
            bool validate = false;
            var randomNumbers = GetRamdomNum(difficulty, operation);
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"\n\tAddition Game! round {round + 1}/5");
                Console.Write($"\n\t{randomNumbers.Item1} {symbolOperator} {randomNumbers.Item2} = ");
                Console.ForegroundColor = ConsoleColor.Blue;

                var userAnswer = Console.ReadLine();

                if (!Helpers.IsValidateAnswer(userAnswer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\tYour answer must be an integer.");
                    Console.ReadKey();
                }
                else
                {
                    var result = DoOperation(randomNumbers, operation);

                    int parsedUserAnswer = int.Parse(userAnswer);
                    bool isAnswerCorrect = result == parsedUserAnswer;
                    if (isAnswerCorrect) correctAnswers++ ;

                    validate = true;
                }

            } while (validate == false);

        }
    }
}
