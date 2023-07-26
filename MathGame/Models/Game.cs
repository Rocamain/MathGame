using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Models
{
    [Serializable()]

    public class Game : ISerializable
    {
        internal string Player { get; set; }
        internal DateTime Date { get; set; }
        internal byte Score { get; set; }
        internal GameType GameType { get; set; }
        internal GameDifficulty GameDifficulty { get; set; }
        internal char OperationSymbol {get; set;}


    public Game() { }

        internal Game(string player, GameType gameType, GameDifficulty gameDifficulty, char operationSymbol)
        {
            Player = player;
            Date = DateTime.Now;
            Score = 0;
            GameType = gameType;
            GameDifficulty = gameDifficulty;
            OperationSymbol = operationSymbol;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} : {5} Pts ", Player, Date, GameDifficulty, GameType, Score);
        }

        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Assign key value pair for your data
            info.AddValue("Player", Player);
            info.AddValue("Date", Date);
            info.AddValue("Score", Score);
            info.AddValue("GameType", GameType);
            info.AddValue("GameDifficulty", GameDifficulty);
        }

        // The deserialize function (Removes Object Data from File)
        public Game(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            Player = (string)info.GetValue("Player", typeof(string));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            Score = (byte)info.GetValue("Score", typeof(byte));
            GameType = (GameType)info.GetValue("GameType", typeof(GameType));
            GameDifficulty = (GameDifficulty)info.GetValue("GameDifficulty", typeof(GameDifficulty));
        }
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




