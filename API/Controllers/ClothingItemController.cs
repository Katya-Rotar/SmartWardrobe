using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingItemController : ControllerBase
    {
        private readonly IClothingItemService _clothingItemService;

        public ClothingItemController(IClothingItemService clothingItemService)
        {
            _clothingItemService = clothingItemService;
        }

        // GET: api/clothingitem
        [HttpGet]
        public ActionResult<PagedList<ClothingItemAllDto>>  GetAllClothingItems([FromQuery] ClothingItemParams parameters)
        {
            var clothingItems = _clothingItemService.GetAllClothingItems(parameters);
            return Ok(clothingItems);
        }

        // GET: api/clothingitem/type/{typeId}
        [HttpGet("type/{typeId}")]
        public async Task<ActionResult> GetItemsByTypeAsync([FromQuery] int userId, int typeId, 
            [FromQuery] ClothingItemParams parameters)
        {
            var clothingItems = await _clothingItemService.GetItemsByTypeAsync(userId, typeId, parameters);
            return Ok(clothingItems);
        }

        // GET: api/clothingitem/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingItemDto>> GetClothingItemById(int id)
        {
            var clothingItem = await _clothingItemService.GetClothingItemByIdAsync(id);
            return Ok(clothingItem);
        }

        // GET: api/clothingitem/details/{id}
        [HttpGet("details/{id}")]
        public async Task<ActionResult<ClothingItem>> GetClothingItemDetailsAsync(int id)
        {
            var clothingItem = await _clothingItemService.GetClothingItemDetailsAsync(id);
            return Ok(clothingItem);
        }

        // GET: api/clothingitem/grouped/{userId}
        [HttpGet("grouped/{userId}")]
        public async Task<ActionResult> GetClothingItemsGroupedByTypeAsync(int userId)
        {
            var result = await _clothingItemService.GetClothingItemsGroupedByTypeAsync(userId);
            return Ok(result);
        }

        // POST: api/clothingitem
        [HttpPost]
        public async Task<ActionResult> AddClothingItemAsync([FromBody] CreateClothingItemDto clothingItemDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var itemId = await _clothingItemService.AddClothingItemAsync(clothingItemDto, cancellationToken);
            return CreatedAtAction(nameof(GetClothingItemById), new { id = itemId }, clothingItemDto);
        }

        // PUT: api/clothingitem/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClothingItemAsync(int id, [FromBody] ClothingItemDto clothingItemDto, 
            CancellationToken cancellationToken)
        {
            await _clothingItemService.UpdateClothingItemAsync(clothingItemDto, cancellationToken);
            return NoContent();
        }

        // DELETE: api/clothingitem/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClothingItemAsync(int id, CancellationToken cancellationToken)
        {
            await _clothingItemService.DeleteClothingItemAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
