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
        Task<UserDTO> PostUserAsinc(CreaUserDTO userDTO);
        Task<UserDTO> GetUserDTOAsync(long id);
        Task<Boolean> PutUserDTOAsync(long id, UserDTO dto);
        Task<Boolean> SetPreferito(long user_id, int prog_id);
        Task<UserDTO> SetPreferiti(List<int> id);
    }
}
