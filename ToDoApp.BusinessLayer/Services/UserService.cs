using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this._mapper = mapper;
            this._db = db;
            this._programmaService = programmaService;
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
                Ruolo = Ruolo.USER
            };

            this._db.Users.Add(user);
            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return this._mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public async Task<UserDTO> GetUserById(long id)
        {
            var userDto = await this._db.Users.FindAsync(id);


            if (userDto == null)
            {
                return null;
            }

            return this._mapper.Map<UserDTO>(userDto);

        }

        public async Task<bool> DeleteUser(long id)
        {
            var user = await _db.Users.FindAsync(id);

            if(user == null)
            {
                return false;
            }

            this._db.Users.Remove(user);
            await this._db.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> UpdateUser(long id, UserDTO userDTO)
        {
            var user = await this._db.Users.FindAsync(id);

            if( user == null)
            {
                return false;
            }

            user.Indirizzo = userDTO.Indirizzo; 
            user.Name = userDTO.Name;
            user.DataNascita = userDTO.DataNascita; 
            user.Email = userDTO.Email;
            user.listaPreferiti = _mapper.Map<List<Programma>>(userDTO.listaPreferiti);

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Boolean> SetPreferito(long user_id, int prog_id)
        {
            var programma = await _db.Programma.AsNoTracking().FirstOrDefaultAsync(x => x.Id == prog_id);
            var user = await this.GetUserById(user_id);
            var res = await _db.SaveChangesAsync();


            if (programma is not null && user is not null)
            {
                user.listaPreferiti.Add(_mapper.Map<ProgrammaDTO>(programma));
                var isDone = await UpdateUser(user_id, user);

                return isDone;
            }
            else throw new Exception();
        }

        public async Task<IEnumerable<ProgrammaDTO>> GetPreferiti(long id)
        {
            var user = await this._db.Users
                .ProjectTo<UserDTO>(this._mapper.ConfigurationProvider)
                .Where(u => u.Id == id)
                .ToListAsync();
            var res = new List<ProgrammaDTO>();
            user.ForEach(u => res = u.listaPreferiti);
            return res;
        }
    }

}
