

using MathGame.Models;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MathGame
{
    internal class Menu
    {

        internal void Show(string name, DateTime date)
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Hello {name}, it's {date.DayOfWeek}'s!!! your lucky day!!!");
          
            ShowGames();
                       
        }

        internal void ShowGames()
        {

            var isGameOn = true;
            do {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($@"
     What game would you like to play today?
     
     V - View Previous Games
     A - Addition
     S - Substraction
     M - Multiplication
     D - Division
     Q - Quit the program"
     );
                Console.Write($@"
     Option: "
);
                Console.ForegroundColor = ConsoleColor.Blue;
                var gameSelected = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;

                
                GameDifficulty difficulty;

                switch (gameSelected)
                {
                    case "v":

                        break;
                    case "a":
                        
                        difficulty = ChooseDifficulty();

                        break;
                    case "s":
                        
                        difficulty = ChooseDifficulty();

                        break;
                    case "m":
                        
                        difficulty = ChooseDifficulty();

                        break;
                    case "d":
                        ;
                        difficulty = ChooseDifficulty();

                        break;
                    case "q":
                        
                        Console.WriteLine("Goodbye !");
                        Console.ReadLine();
                        isGameOn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, press any key to go back in the menu.");
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
             
                Console.WriteLine($@"
     Choose a difficulty:

     E - Easy
     M - Medium
     H - Hard");

                Console.Write($@"
     Option: ");
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
                        Console.WriteLine("Invalid input, press any key to go back in the menu.");
                        Console.ReadLine();
                        break;
                }
            } while (input == false);

            return difficulty;
        }
    }
}



