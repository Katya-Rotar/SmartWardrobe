namespace DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClothingItemRepository ClothingItems { get; }
    Task SaveAsync();
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}