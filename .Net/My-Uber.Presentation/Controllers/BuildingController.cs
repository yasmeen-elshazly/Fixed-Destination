using Microsoft.AspNetCore.Mvc;
using My_Uber.DTOs;
using My_Uber.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Uber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        // GET: api/building
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingDTO>>> GetAll()
        {
            var buildings = await _buildingService.GetAllAsync();
            return Ok(buildings);
        }

        // GET: api/building/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDTO>> GetById(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        // POST: api/building
        [HttpPost]
        public async Task<ActionResult<BuildingDTO>> Create([FromBody] BuildingDTO buildingDto)
        {
            if (buildingDto == null)
            {
                return BadRequest();
            }

            var createdBuilding = await _buildingService.CreateAsync(buildingDto);

            return CreatedAtAction(nameof(GetById), new { id = createdBuilding.Id }, createdBuilding);
        }

        // PUT: api/building/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BuildingDTO buildingDto)
        {
            if (id != buildingDto.Id)
            {
                return BadRequest();
            }

            var result = await _buildingService.UpdateAsync(buildingDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/building/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _buildingService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
