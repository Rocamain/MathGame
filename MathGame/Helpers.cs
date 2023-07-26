
using MathGame.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace MathGame
{
    internal class Helpers
    {
        const string scoresPath = @"C:\mathGame\scores.txt";
        const string gameDirectory = @"C:\mathGame";

        internal static List<Game> games = new();

        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
        }

        internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty gameDificulty)
        {
            
        }

        /// <summary>
        /// render a screen asking for player name and return it
        /// </summary>
        /// <returns>Player Name</returns>
        internal static string GetName()
        {
            var askName = () => {
                Console.Clear();                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\n\tWellcome to the Math challenge game!!!");
                Console.Write("\n\tWhat's your name? ");

                Console.ForegroundColor = ConsoleColor.Blue;
                
                string name = Console.ReadLine();
                
                if (name != null)
                {
                   name =  name.Trim();
                    return name.Length > 0 ? name : null;    
                }

                 return null;
            };
            string name = askName();          
            
            // is name is empty or null display message and ask agin for the name
            while (string.IsNullOrEmpty(name)) {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tName cannot be empty. type to continue");
                Console.ReadKey();
                name = askName();
            }

            Console.Clear();
            return name;
        }

        /// <summary>
        /// Make the valiadtion for the string passed is a integer
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <returns> boolean  </returns>
        internal static bool IsValidateAnswer(string userAnswer)
        {
            bool isValid = string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _)? false: true;

            return isValid;
        }
    }    
}
