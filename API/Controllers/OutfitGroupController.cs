using BLL.DTO.OutfitGroup;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitGroupController : ControllerBase
    {
        private readonly IOutfitGroupService _outfitGroupService;

        public OutfitGroupController(IOutfitGroupService outfitGroupService)
        {
            _outfitGroupService = outfitGroupService;
        }

        // GET: api/outfitgroup/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OutfitGroupDto>>> GetGroupsByUserId(int userId)
        {
            var groups = await _outfitGroupService.GetByUserIdAsync(userId);
            return Ok(groups);
        }

        // GET: api/outfitgroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutfitGroupDto>> GetGroupById(int id)
        {
            var group = await _outfitGroupService.GetByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        // POST: api/outfitgroup
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateOutfitGroupDto dto,
            CancellationToken cancellationToken)
        {
            await _outfitGroupService.CreateAsync(dto, cancellationToken);
            return StatusCode(201);
        }

        // PUT: api/outfitgroup
        [HttpPut]
        public async Task<IActionResult> UpdateGroup([FromBody] OutfitGroupDto dto, CancellationToken cancellationToken)
        {
            await _outfitGroupService.UpdateAsync(dto, cancellationToken);
            return NoContent();
        }

        // DELETE: api/outfitgroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id, CancellationToken cancellationToken)
        {
            await _outfitGroupService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
