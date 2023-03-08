using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.BusinessLayer.Services.Interfaces;
using ToDoApp.DataAccessLayer;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Services
{
    public class AziendaService : ITAziendaService
    {
        private readonly IMapper _mapper;
        private readonly TodoappContext _db;

        public AziendaService(IMapper mapper, TodoappContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }
        public async Task<IEnumerable<AziendaDTO>> getAll()
        {
            return await this._db.Aziendas
                  .ProjectTo<AziendaDTO>(this._mapper.ConfigurationProvider)
                  .ToListAsync();

        }

        public async Task<AziendaDTO> PostAzienda(AziendaDTO aziendaDTO)
        {
            var azienda = new Azienda
            {
                Name = aziendaDTO.Name,
                // Programmi
            };

            this._db.Aziendas.Add(azienda);

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return this._mapper.Map<AziendaDTO>(azienda);
            }
            return null;
        }
    }
}
