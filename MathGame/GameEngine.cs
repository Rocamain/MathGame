using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {

        internal void StartGame (GameType operation , GameDifficulty difficulty, char operationSymbol) {
           
            for(var round = 0; round < 5; round++)
            {
                var RandomNumbers = GetRamdomNum(difficulty, operation);
                var result = DoOperation(RandomNumbers, operation);
                string userAnswer = "";

                Helpers.RenderOperation(RandomNumbers, ref userAnswer, round , operationSymbol);
            }
                          
        }
        internal int DoOperation ((int FirstInt, int SecondInt) numbers, GameType operation)
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

        internal (int , int) GetRamdomNum(GameDifficulty difficulty, GameType operation)
        {

            var random = new Random();
            int numberSize = 9;

            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    numberSize = operation== GameType.Division ? 99: 9;
                    break;
                case GameDifficulty.Medium:
                    numberSize = operation == GameType.Division ? 999:99;
                    break;
                case GameDifficulty.Hard:
                    numberSize = operation == GameType.Division ? 9999:999;
                    break;
            }

          

            int firstNumber = random.Next(1, numberSize);
            int secondNumber = random.Next(1, numberSize);
            if(operation == GameType.Division) {
                
                while (firstNumber % secondNumber != 0)
                {
                     firstNumber = random.Next(1, numberSize);
                     secondNumber = random.Next(1, numberSize);
                    
                }
              
            }
            
            return (firstNumber, secondNumber);
            
        }
    }
}
