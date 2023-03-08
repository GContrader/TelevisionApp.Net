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
    public class UserService : ITUserService
    {
        private readonly IMapper _mapper;
        private readonly TodoappContext _db;

        public UserService(IMapper mapper, TodoappContext db)
        {
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

        public async Task<UserDTO> PostUserAsinc(UserDTO userDTO)
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

            var isDone = await this._db.SaveChangesAsync();

            if (isDone > 0)
            {
                return true;
            }

            return false;
        }
    }

}
