using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.BusinessLayer.Services.Interfaces;
using ToDoApp.DataAccessLayer;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Services
{
    public class UserService : ITUserService
    {
        private readonly IMapper _mapper;
        private readonly TodoappContext _db;
        private readonly IProgrammaService _programmaService;

        public UserService(IMapper mapper, TodoappContext db, IProgrammaService programmaService)
        {
            _programmaService = programmaService;
            this._mapper = mapper;
            this._db = db;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsinc()
        {
            return await this._db.Users
                .ProjectTo<UserDTO>(this._mapper.ConfigurationProvider)
                .ToListAsync();
;
        }

        public async Task<UserDTO> PostUserAsinc(CreaUserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                DataNascita = userDTO.DataNascita,
                Indirizzo = userDTO.Indirizzo,
                Ruolo = Ruolo.USER,
                listaPreferiti = new List<Programma>()
            };
            var programma = _mapper.Map<Programma>(await _programmaService.GetProgrammaDTOAsync(1));
            user.listaPreferiti.Add(programma);
            
            this._db.Users.Add(user);
            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return this._mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public async Task<bool> PutUserDTOAsync(long id, UserDTO userdto)
        {
            var item = await this._db.Users.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            item.listaPreferiti = _mapper.Map<List<Programma>>(userdto.listaPreferiti);

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<UserDTO> GetUserDTOAsync(long id)
        {
            var dto = await this._db.Users.FindAsync(id);

            if (dto is not null)
            {
                return this._mapper.Map<UserDTO>(dto);
            }
            return null;
        }

        public Task<UserDTO> SetPreferiti(List<int> id)
        {
            throw new NotImplementedException();
        }

        public async Task<Boolean> SetPreferito(long user_id, int prog_id)
        {

            var programma = await _db.Programma.AsNoTracking().FirstOrDefaultAsync(x => x.Id == prog_id);
            var user = await GetUserDTOAsync(user_id);
            
            if(programma is not null && user is not null)
            {
                if(user.listaPreferiti is null) { user.listaPreferiti = new List<ProgrammaDTO>(); }
                user.listaPreferiti.Add(_mapper.Map<ProgrammaDTO>(programma));

                var res = this.PutUserDTOAsync(user_id, user);
                if(res.IsCompletedSuccessfully)
                {
                    return true;
                }
                return false;
            } 
            else throw new Exception();
            //TODO creare nuove eccezioni
        }

        
    }
}
