using BLL.DTO.Type;

namespace BLL.Services.Interfaces;

public interface ITypeService
{
    Task<IEnumerable<TypeDto>> GetAll();
    Task<IEnumerable<TypeDto>> GetTypesByCategoryIdAsync(int categoryId);
}