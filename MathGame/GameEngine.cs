using MathGame.Models;
using static System.Formats.Asn1.AsnWriter;
using System.Security.AccessControl;

namespace MathGame
{
    internal class GameEngine
    {
        

        internal void StartGame (GameType gameType , GameDifficulty gameDifficulty, char operationSymbol, string player ) {
            
            Game currentGame = new Game(player, gameType, gameDifficulty, operationSymbol);

            for (var round = 0; round < 5; round++)
            {
                RenderOperation( round, currentGame);

                if(round == 4) {
                    // pending implmentation
                    
                    Console.WriteLine("Final Score: {0}", currentGame.Score);
                    Console.ReadKey();
                  //  Helpers.AddToHistory(gameScore, operation, difficulty);
                }
            }    
        }

        /// <summary>
        /// Will receive the number and will do a a mathematical operation
        /// </summary>
        /// <param name="numbers">Tuple of a given random numbers</param>
        /// <param name="gameType">Enum for type of opeation</param>
        /// <returns></returns>
        private static int DoOperation ((int FirstInt, int SecondInt) numbers, GameType gameType)
        {
            int result = 0;
            switch (gameType)
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
        /// </summary>
        /// <param name="gameDifficulty"> enum </param>
        /// <param name="gameType"> enum </param>
        /// <returns> tuple of integers </returns>
        private static (int , int) GetRamdomNums(GameDifficulty gameDifficulty, GameType gameType)
        {
            var random = new Random();
            int numberSize = 9;

            switch (gameDifficulty)
            {
                case GameDifficulty.Easy:
                    numberSize = gameType == GameType.Division ? 99: 9;
                    break;
                case GameDifficulty.Medium:
                    numberSize = gameType == GameType.Division ? 999:99;
                    break;
                case GameDifficulty.Hard:
                    numberSize = gameType == GameType.Division ? 9999:999;
                    break;
            }

            var firstNumber = random.Next(1, numberSize);
            var secondNumber = random.Next(1, numberSize);

            if (gameType == GameType.Division)
            {
                /// While loop that will that will execute create random numbers until it find a multiple set of
                /// numbers that its division returns a integer.
                while (firstNumber % secondNumber != 0)
                {
                     firstNumber = random.Next(1, numberSize);
                     secondNumber = random.Next(1, numberSize);   
                }  
            }
            
            return (firstNumber, secondNumber);
        }

        /// <summary>
        /// Will render the opeation on the screen will create a set of radom numbers by calling GetRamdomNums, 
        /// then will executo the opeation internaly with DoOperation and in case is correct will add +1 to score
        /// of the currentGame class object.
        /// </summary>
        /// <param name="round">round of the loop</param>
        /// <param name="currentGame">game object</param>
        internal static void RenderOperation( int round, Game currentGame)
        {
            bool validate = false;
            var randomNumbers = GetRamdomNums(currentGame.GameDifficulty, currentGame.GameType);
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"\n\tAddition Game! round {round + 1}/5");
                Console.Write($"\n\t{randomNumbers.Item1} {currentGame.OperationSymbol} {randomNumbers.Item2} = ");
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
                    var result = DoOperation(randomNumbers, currentGame.GameType);

                    int parsedUserAnswer = int.Parse(userAnswer);
                    
                    bool isAnswerCorrect = result == parsedUserAnswer;
                    if (isAnswerCorrect) currentGame.Score++; ;

                    validate = true;
                }

            } while (validate == false);
        }
    }
}
