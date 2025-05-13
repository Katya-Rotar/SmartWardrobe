using DAL.Context;
using DAL.Repositories.Interfaces;
using Type = DAL.Entities.Type;

namespace DAL.Repositories;

public class TypeRepository : GenericRepository<Type>, ITypeRepository
{
    public TypeRepository(WardrobeDbContext context) : base(context)
    {
    }
}