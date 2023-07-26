using System.Runtime.Serialization;

// With serialization you can store the state 
// of an object in a file stream, pass it to
// a remote network

namespace MathGame.Models
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class Game : ISerializable
    {
        public string Player { get; set; }
        public DateTime Date { get; set; }
        public byte Score { get; set; }

        public GameType GameType { get; set; }
        public GameDifficulty GameDifficulty { get; set; }
        public string OperationSymbol { get; set; }

        public Game() { }

        public Game(string player, GameType gameType, GameDifficulty gameDifficulty, string operationSymbol)
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
            return string.Format("Player: {0} Date: {1} Level: {2} Type: {3} Points: {4}", Player, Date, GameDifficulty, GameType, Score);
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

    public enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}