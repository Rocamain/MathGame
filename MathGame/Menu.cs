
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace MathGame
{
    internal class Menu
    {
        internal void Show( string name)
        {
            
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Hello {name}, Good Luck!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            

            Console.WriteLine($@"
     What game would you like to play today?

     Choose from the options below:

     V - View Previous Games
     A - Addition
     S - Substraction
     M - Multiplication
     D - Division
     Q - Quit the program");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
