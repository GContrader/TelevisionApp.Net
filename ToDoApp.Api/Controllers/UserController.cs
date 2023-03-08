using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITUserService _userService;

        public UserController(ITUserService userService)
        {
            this._userService = userService;    
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserDto()
        {
            return this.Ok(await this._userService.GetUsersAsinc());
        }
    }
}
