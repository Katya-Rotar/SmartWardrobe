using AutoMapper;
using BLL.DTO.Type;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class TypeService : ITypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeDto>> GetAll()
    {
        var types = await _unitOfWork.Types.GetAllAsync();
        return _mapper.Map<IEnumerable<TypeDto>>(types);
    }
}