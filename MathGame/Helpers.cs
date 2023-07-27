using System.Xml.Serialization;
using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        const string gameFilePath = @"C:\mathGame\scores.xml";
        const string gameDirectoryPath = @"C:\mathGame";

        internal static List<Game> games = new();

        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("\n\tGames history:");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------");
            PrintGameRecords();
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n\tPress any key to go back to the menu");
            Console.ReadLine();
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
                
                string? name = Console.ReadLine();
                
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

        // SaveRecordFuntion function (Stores Object Data in File)
        // Calls Streaming ReadFile function  read the file add them to games field list of this class
        // Then attached the currentGame file to the games List and serialized them and writte them on 
        // by the StreamWritter.
        internal static void SaveGameRecord(ref Game? currentGame)
        {
            ReadFile();
            games.Add(currentGame); 

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));
                using (TextWriter tw = new StreamWriter(gameFilePath))
                {
                    serializer.Serialize(tw, games);
                }
                // Delete currentGame data            
                currentGame = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
        internal static  void CreateDirectory ()
        {
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(gameDirectoryPath))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(gameDirectoryPath);         
                }    

                return;  
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }

        // ReadFile function (Stream read a list Object Data from File)
        // add them to games field list of this class
        internal static void ReadFile ()
        {
            try { 
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Game>));
            TextReader reader = new StreamReader(gameFilePath);
            object? obj = deserializer.Deserialize(reader);
            games = (List<Game>)obj;
            reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ");
            }
        }
        private static void PrintGameRecords ()
        {
            ReadFile();
            var gamesToPrint = games.OrderBy(game => game.Date).OrderByDescending(game => game.Score);

            foreach (Game game in games)
            {
                Console.WriteLine("\t{0}", game.ToString());
            };
        }
    }    
}
