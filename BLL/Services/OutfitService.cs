using AutoMapper;
using BLL.DTO.Outfit;
using BLL.Services.Interfaces;
using DAL.Helpers;
using DAL.Helpers.Params;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class OutfitService : IOutfitService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OutfitService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public PagedList<OutfitDto> GetAllOutfit(OutfitParams parameters)
    {
        var outfit = _unitOfWork.Outfits.GetAllOutfit(parameters);
        return _mapper.Map<PagedList<OutfitDto>>(outfit);
    }

    public async Task<OutfitDto?> GetOutfitDetailsAsync(int id)
    {
        var outfit = await _unitOfWork.Outfits.GetOutfitDetailsAsync(id);
        return _mapper.Map<OutfitDto>(outfit);
    }

    public async Task<IEnumerable<OutfitDto>> GetOutfitsByItemIdAsync(int itemId)
    {
        var outfit = await _unitOfWork.Outfits.GetOutfitsByItemIdAsync(itemId);
        return _mapper.Map<IEnumerable<OutfitDto>>(outfit);
    }
}