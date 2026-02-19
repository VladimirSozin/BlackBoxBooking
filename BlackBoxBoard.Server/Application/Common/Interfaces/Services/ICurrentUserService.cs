namespace BlackBoxBoard.Server.Application.Common.Interfaces;

public interface ICurrentUserService
{
    int? UserId { get; }
    string? UserName { get; }
    string[] Roles { get; }
    bool IsAuthenticated { get; }
}
