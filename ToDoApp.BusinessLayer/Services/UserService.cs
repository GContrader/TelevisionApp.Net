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
    }
}
