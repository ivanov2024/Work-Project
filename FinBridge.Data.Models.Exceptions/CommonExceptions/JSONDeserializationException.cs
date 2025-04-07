namespace FinBridge.Data.Models.Exceptions.CommonExceptions
{
    public class JSONDeserializationException : FinBridgeException
    {
        public JSONDeserializationException(string fileName)
            :base($"Failed to deserialize data from file '{fileName}'") { }
    }
}
