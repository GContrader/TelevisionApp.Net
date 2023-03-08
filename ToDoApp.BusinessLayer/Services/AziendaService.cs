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

        public async Task<bool> DeleteAzienda(long id)
        {
            var azienda = await _db.Aziendas.FindAsync(id);

            if(azienda == null)
            {
                return false;
            }
            this._db.Aziendas.Remove(azienda);  
            await this._db.SaveChangesAsync();  
            return true;
        }

        public async Task<IEnumerable<AziendaDTO>> getAll()
        {
            return await this._db.Aziendas
                  .ProjectTo<AziendaDTO>(this._mapper.ConfigurationProvider)
                  .ToListAsync();

        }

        public async Task<AziendaDTO> getAziendaById(long id)
        {
            var aziendaDto = await this._db.Aziendas.FindAsync(id);

            if(aziendaDto == null)
            {
                return null;
            }
            return this._mapper.Map<AziendaDTO>(aziendaDto);
        }

        public async Task<AziendaDTO> PostAzienda(AziendaDTO aziendaDTO)
        {
            var azienda = new Azienda
            {
                Name = aziendaDTO.Name,
                Programmi = aziendaDTO.Programmi
            };

            this._db.Aziendas.Add(azienda);

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return this._mapper.Map<AziendaDTO>(azienda);
            }
            return null;
        }

        public async Task<bool> UpdateAzienda(long id, AziendaDTO aziendaDTO)
        {
            var azienda = await this._db.Aziendas.FindAsync(id);  
            
            if(azienda == null)
            {
                Console.WriteLine("Azienda non trovata");
            }
            azienda.Name = aziendaDTO.Name;
            azienda.Programmi = azienda.Programmi;

            var isDone = await this._db.SaveChangesAsync();

            if(isDone > 0)
            {
                return true;
            }
            return false;   
        }
    }
}
