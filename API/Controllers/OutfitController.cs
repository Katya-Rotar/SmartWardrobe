using BLL.DTO.Outfit;
using BLL.Services.Interfaces;
using DAL.Helpers;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitService _outfitService;

        public OutfitController(IOutfitService outfitService)
        {
            _outfitService = outfitService;
        }

        // GET: api/Outfit
        [HttpGet]
        public ActionResult<PagedList<OutfitDto>> GetAllOutfits([FromQuery] OutfitParams parameters)
        {
            var outfit = _outfitService.GetAllOutfit(parameters);
            return Ok(outfit);
        }

        // GET: api/Outfit/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OutfitDto>> GetOutfitDetails(int id)
        {
            var outfit = await _outfitService.GetOutfitDetailsAsync(id);
            if (outfit == null)
                return NotFound();

            return Ok(outfit);
        }

        // GET: api/Outfit/by-item/{itemId}
        [HttpGet("by-item/{itemId}")]
        public async Task<ActionResult<IEnumerable<OutfitDto>>> GetOutfitsByItemId(int itemId)
        {
            var outfits = await _outfitService.GetOutfitsByItemIdAsync(itemId);
            return Ok(outfits);
        }
    }
}