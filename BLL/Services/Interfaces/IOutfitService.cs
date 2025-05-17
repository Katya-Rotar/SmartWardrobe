using BLL.DTO.Outfit;

namespace BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using DAL.Helpers.Params;

public interface IOutfitService
{
    PagedList<OutfitDto> GetAllOutfit(OutfitParams parameters);
    Task<OutfitDto?> GetOutfitDetailsAsync(int id);
    Task<IEnumerable<OutfitDto>> GetOutfitsByItemIdAsync(int itemId);
}