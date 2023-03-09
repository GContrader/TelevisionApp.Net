using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsinc();
        Task<UserDTO> PostUserAsinc(CreaUserDTO userDTO);

        Task<UserDTO> GetUserById(long id);

        Task<bool> DeleteUser(long id);

        Task <bool> UpdateUser(long id, UserDTO userDTO);

        Task<bool> SetPreferito(long id, int id_prog);

        Task<IEnumerable<ProgrammaDTO>> GetPreferiti(long id);

    }
}
