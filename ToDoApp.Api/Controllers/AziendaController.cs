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

        [HttpGet("{id}")]
        public async Task<ActionResult<AziendaDTO>> getAziendaByid(long id)
        {
            return this.Ok(await this._aziendaService.getAziendaById(id));
        }

        //ADMIN e AZIENDA

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteAzienda(long id)
        {
            return this.Ok(await this._aziendaService.DeleteAzienda(id));   
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> updateAzienda(long id, AziendaDTO aziendaDTO)
        {
            return this.Ok(await this._aziendaService.UpdateAzienda(id, aziendaDTO));   
        }

        [HttpPost]
        public async Task<ActionResult<AziendaDTO>> postAzienda(AziendaDTO aziendaDTO)
        {
            return this.Ok(await this._aziendaService.PostAzienda(aziendaDTO));   
        }


    }
}
