using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.BusinessLayer.Services.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammaController : ControllerBase
    {
        private readonly IProgrammaService programmaService;

        public ProgrammaController(IProgrammaService programmaService)
        {
            this.programmaService = programmaService;
        }

        // GET: api/   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammaDTO>>> GetProgrammi()
        {
            var response = await this.programmaService.GetProgrammaDTOAsync();
            return this.Ok(response);
        }

        // GET: api/../1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammaDTO>> GetProgramma(int id)
        {
            var dto = await this.programmaService.GetProgrammaDTOAsync(id);

            if (dto == null)
            {
                return NotFound();
            }

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<ProgrammaDTO>> PostProgramma(CreaProgrammaDTO dto)
        {
            var itemInsert = await this.programmaService.PostProgrammaDTOAsync(dto);

            if (itemInsert is not null)
            {
                return CreatedAtAction(
                    nameof(GetProgramma),
                    new { id = itemInsert.Id },
                    itemInsert
                );
            }

            return BadRequest();
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramma(int id, CreaProgrammaDTO dto)
        {
            var updateItem = await this.programmaService.PutProgrammaDTOAsync(id, dto);

            if (updateItem == false)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var isDeleted = await this.programmaService.DeleteProgrammaDTOAsync(id);
            if (isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}