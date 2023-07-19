using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Models
{
    internal class Game
    {
        internal DateTime Date { get; set; }
        internal int Score { get; set; }
        internal GameType GameType { get; set; }
        internal GameDifficulty GameDifficulty { get; set; }
    }

    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}
