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
    public ITemperatureSuitabilityRepository TemperatureSuitability { get; }
    public IStyleRepository Styles { get; }
    public ISeasonRepository Seasons { get; }

    public UnitOfWork(WardrobeDbContext context,
        IClothingItemRepository clothingItem, ICategoryRepository categories, ITypeRepository types, 
        ITemperatureSuitabilityRepository temperatureSuitability, IStyleRepository styles,
        ISeasonRepository seasons)
    {
        _context = context;
        ClothingItems = clothingItem;
        Categories = categories;
        Types = types;
        TemperatureSuitability = temperatureSuitability;
        Styles = styles;
        Seasons = seasons;
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