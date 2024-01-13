namespace NetasBank.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }
    }
}
