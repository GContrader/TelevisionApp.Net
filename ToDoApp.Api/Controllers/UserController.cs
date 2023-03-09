using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using ToDoApp.BusinessLayer.Models;
using Serilog;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserDto()
        {
            return this.Ok(await this._userService.GetUsersAsinc());
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(CreaUserDTO userDTO)
        {
            return this.Ok(await this._userService.PostUserAsinc(userDTO));
        }

        //ADMIN

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateUser(long id, UserDTO userDto)
        {
            return this.Ok(await this._userService.UpdateUser(id, userDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(long id)
        {
            return this.Ok(await this._userService.DeleteUser(id));
        }

        [HttpPut("preferito")]
        public async Task<ActionResult<bool>> SetPreferito(long user_id, int prog_id)
        {
            return this.Ok(await this._userService.SetPreferito(user_id, prog_id));
        }

        [HttpGet("lista-preferiti")]
        public async Task<ActionResult<IEnumerable<ProgrammaDTO>>> GetPreferiti(long user_id)
        {
            return this.Ok(await this._userService.GetPreferiti(user_id));
        }

    }
}