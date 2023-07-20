
using MathGame.Models;

namespace MathGame
{
    internal class Helpers

    {

        internal static List<Game> games = new();

        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
           
        }
        internal static string GetName()
        {
            
            var askName = () => {
                Console.Clear();
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Wellcome to the Math challenge game!!!");
                Console.Write("\n What's your name? ");
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
            
                        

            while (string.IsNullOrEmpty(name)) {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Name cannot be empty. type to continue");
                name = Console.ReadLine();
                name = askName();
                
            }

            Console.Clear();
            return name;
        }

        internal static bool ValidateResult(string result)
        {
            if (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
            {
                
                return false;
            }
            else
            {
                return true;
            }
            
        }

        internal static  void  RenderOperation ((int FirstInt, int SecondInt) numbers, ref string  userAnswer, int round , char symbolOperator)
        {
            bool validate = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($@"
     Addition Game! round {round + 1 }/5");
                Console.Write($@"
     {numbers.FirstInt} {symbolOperator} {numbers.SecondInt} = ");
                Console.ForegroundColor = ConsoleColor.Blue;

                userAnswer = Console.ReadLine();

                if (!ValidateResult(userAnswer))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($@"

     Your answer must be an integer.");
                    validate = false;
                    Console.ReadKey();

                }
                else
                {
                    validate = true;


                    
                }

              


            } while (validate == false);

        }
    }

    
}
