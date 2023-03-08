using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.BusinessLayer.Services.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AziendaController : ControllerBase
    {
        private readonly ITAziendaService _aziendaService;

        public AziendaController(ITAziendaService aziendaService)
        {
            this._aziendaService = aziendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AziendaDTO>>> getAll()
        {
            return this.Ok(await this._aziendaService.getAll());    
        }
    }
}
