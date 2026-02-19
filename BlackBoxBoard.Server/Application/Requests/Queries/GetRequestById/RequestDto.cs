namespace BlackBoxBoard.Server.Application.Requests.Queries.GetRequestById
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
