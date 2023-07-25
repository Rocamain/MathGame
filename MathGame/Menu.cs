using MathGame.Models;


namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new GameEngine();
        internal void Show(string name, DateTime date)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\tHello {name}, it's {date.DayOfWeek}'s!!! your lucky day!!!\n");
          
            ShowGames();         
        }

        internal void ShowGames()
        {

            var isGameOn = true;
            do {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tWhat game would you like to play today?\n\n" + 
                    "\tV - View Previous Games\n" +
                    "\tA - Addition\n" +
                    "\tS - Substraction\n" +
                    "\tM - Multiplication\n" +
                    "\tD - Division\n" +
                    "\tQ - Quit the program\n"                     
                    );
                
                Console.Write($"\tOption: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                var option = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;
                                
                GameDifficulty difficulty;
                GameType gameType;
                

                switch (option)
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        
                        difficulty = ChooseDifficulty();
                        gameType = Models.GameType.Addition;
                        gameEngine.StartGame(gameType, difficulty, '+');

                        break;
                    case "s":

                        difficulty = ChooseDifficulty();
                        gameType = Models.GameType.Substraction;
                        gameEngine.StartGame(gameType, difficulty, '-');

                        break;
                    case "m":

                        difficulty = ChooseDifficulty();
                        gameType = Models.GameType.Multiplication;
                        gameEngine.StartGame(gameType, difficulty, '*');

                        break;
                    case "d":
                        
                        difficulty = ChooseDifficulty();
                        gameType = Models.GameType.Division;
                        gameEngine.StartGame(gameType, difficulty, '/');

                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine(" Goodbye !");
                        Console.ReadLine();
                        isGameOn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.Write("\n\tInvalid input, press any key to go back in the menu.");
                        Console.ReadLine();
                        
                        break;
                }
                Console.Clear();


            } while (isGameOn);

        }

        internal static GameDifficulty ChooseDifficulty()
        {
            bool input = false;
            GameDifficulty difficulty = new GameDifficulty();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tChoose a difficulty:\n\n" +
                                 "\tE - Easy\n" +
                                 "\tM - Medium\n" +
                                 "\tH - Hard\n");

                Console.Write($"\tOption: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                var gameDifficulty = Console.ReadLine().ToLower().Trim();

                switch (gameDifficulty)
                {
                    case "e":
                        difficulty = Models.GameDifficulty.Easy;
                        input = true;
                        break;
                    case "m":
                        difficulty = Models.GameDifficulty.Medium;
                        input = true;
                        break;
                    case "h":
                        difficulty = Models.GameDifficulty.Hard;
                        input = true;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\tInvalid input, press any key to go back in the menu.");
                        Console.ReadLine();
                        break;
                }
            } while (input == false);

            return difficulty;
        }
    }
}



