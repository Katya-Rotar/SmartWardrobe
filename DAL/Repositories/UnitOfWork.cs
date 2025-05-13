using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly WardrobeDbContext _context;
    private IDbContextTransaction _transaction;
    
    public IClothingItemRepository ClothingItems { get; }
    public ICategoryRepository Categories { get; }
    public ITypeRepository Types { get; }

    public UnitOfWork(WardrobeDbContext context,
        IClothingItemRepository clothingItem, ICategoryRepository categories, ITypeRepository types)
    {
        _context = context;
        ClothingItems = clothingItem;
        Categories = categories;
        Types = types;
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }
}