using BLL.DTO.Type;

namespace BLL.Services.Interfaces;

public interface ITypeService
{
    Task<IEnumerable<TypeDto>> GetAll();
}