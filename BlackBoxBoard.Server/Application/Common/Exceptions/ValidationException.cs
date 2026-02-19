namespace BlackBoxBoard.Server.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Ошибка валидации")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IDictionary<string, string[]> errors)
            : this()
        {
            Errors = errors;
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
