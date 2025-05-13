using BLL.DTO.Type;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var type = await _typeService.GetAll();
            return Ok(type);
        }
    }
}