namespace BlackBoxBoard.Server.Domain.Common;

public interface ISoftDelete
{
    bool IsActive { get; }
    DateTime? DeletedAt { get; }
    int? DeletedBy { get; }
}
