using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.BusinessLayer.Services.Interfaces
{
    public interface ITUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsinc();
        Task<UserDTO> PostUserAsinc(UserDTO userDTO);

        Task<UserDTO> GetUserById(long id);

        Task<bool> DeleteUser(long id);

        Task <bool> UpdateUser(long id, UserDTO userDTO);

    }
}
