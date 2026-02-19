namespace BlackBoxBoard.Server.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Сущность \"{name}\" ({key}) не найдена.")
        {
        }
    }
}
