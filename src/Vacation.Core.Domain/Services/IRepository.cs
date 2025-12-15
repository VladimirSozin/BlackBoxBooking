using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services;

/// <summary>
/// Repository interface for entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Saves the entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to save.</param>
    /// <returns>The result.</returns>
    Task<Result<TEntity>> SaveAsync(TEntity entity);

    /// <summary>
    /// Deletes the entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>The result.</returns>
    Task<Result<TEntity>> DeleteAsync(TEntity entity);

    /// <summary>
    /// Gets entities asynchronously based on predicate.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns>The result with the list of entities.</returns>
    Task<Result<IReadOnlyList<TEntity>>> GetAsync(Predicate<TEntity> predicate);
}
