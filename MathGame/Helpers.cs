using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Helpers
    {
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
    }
}
