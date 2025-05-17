using AutoMapper;
using BLL.DTO.Outfit;
using BLL.Services.Interfaces;
using DAL.Entities;
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
    
    public async Task<int> CreateOutfitAsync(CreateOutfitDto dto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var outfit = new Outfit
            {
                UserID = dto.UserID,
                TemperatureSuitabilityID = dto.TemperatureSuitabilityID,
                Tags = dto.TagIDs.Select(id => new OutfitTag { TagID = id }).ToList(),
                Styles = dto.StyleIDs.Select(id => new OutfitStyle { StyleID = id }).ToList(),
                Seasons = dto.SeasonIDs.Select(id => new OutfitSeason { SeasonID = id }).ToList(),
                Items = dto.ClothingItemIDs.Select(id => new OutfitItem { ClothingItemID = id }).ToList(),
                GroupItems = dto.OutfitGroupIDs != null && dto.OutfitGroupIDs.Any()
                    ? dto.OutfitGroupIDs.Select(id => new OutfitGroupItem { OutfitGroupID = id }).ToList()
                    : new List<OutfitGroupItem>()
            };

            await _unitOfWork.Outfits.AddAsync(outfit);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return outfit.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateOutfitAsync(UpdateOutfitDto outfitDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var outfit = await _unitOfWork.Outfits.GetOutfitDetailsAsync(outfitDto.Id);
            if (outfit == null)
                throw new KeyNotFoundException("Outfit not found");
        
            outfit.TemperatureSuitabilityID = outfitDto.TemperatureSuitabilityID;

            outfit.Tags.Clear();
            outfit.Styles.Clear();
            outfit.Seasons.Clear();
            outfit.Items.Clear();
            outfit.GroupItems.Clear();

            outfit.Tags = outfitDto.TagIDs.Select(id => new OutfitTag { TagID = id, OutfitID = outfit.Id }).ToList();
            outfit.Styles = outfitDto.StyleIDs.Select(id => new OutfitStyle { StyleID = id, OutfitID = outfit.Id }).ToList();
            outfit.Seasons = outfitDto.SeasonIDs.Select(id => new OutfitSeason { SeasonID = id, OutfitID = outfit.Id }).ToList();
            outfit.Items = outfitDto.ClothingItemIDs.Select(id => new OutfitItem { ClothingItemID = id, OutfitID = outfit.Id }).ToList();

            if (outfitDto.OutfitGroupIDs != null && outfitDto.OutfitGroupIDs.Any())
            {
                outfit.GroupItems = outfitDto.OutfitGroupIDs
                    .Select(id => new OutfitGroupItem { OutfitGroupID = id, OutfitID = outfit.Id })
                    .ToList();
            }
            else
            {
                outfit.GroupItems = new List<OutfitGroupItem>();
            }

            _unitOfWork.Outfits.UpdateAsync(outfit);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteOutfitAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var outfit = await _unitOfWork.Outfits.GetByIdAsync(id);
            if (outfit == null) throw new KeyNotFoundException("outfit not found.");

            await _unitOfWork.Outfits.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}