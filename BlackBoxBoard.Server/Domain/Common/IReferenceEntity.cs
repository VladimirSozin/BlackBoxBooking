namespace BlackBoxBoard.Server.Domain.Common
{
    public interface IReferenceEntity
    {
        string Code { get; }
        string Name { get; }
        int SortOrder { get; }
        bool IsActive { get; }
    }
}
