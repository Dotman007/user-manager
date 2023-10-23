using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Interface;
using UserManager.Domain.Dto;

namespace UserManager.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost]
        
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userOk = await _userService.CreateUser(user);
            return Ok(userOk);
        }


        [AllowAnonymous]
        [HttpPut("{id}")]

        public async Task<IActionResult> EditUser(string id,[FromBody] EditUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userOk = await _userService.EditUser(id,user);
            return Ok(userOk);
        }


        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> SearchUser(string param)
        {
            var userOk = await _userService.SearchUser(param);
            return Ok(userOk);
        }


        [AllowAnonymous]
        [HttpDelete]

        public async Task<IActionResult> DeleteUser([FromBody] string id)
        {
            var userOk = await _userService.DeleteUser(id);
            return Ok(userOk);
        }


        [AllowAnonymous]
        [HttpDelete]

        public async Task<IActionResult> DeleteMultipleUser([FromBody]List<string> id)
        {
            var userOk = await _userService.DeleteMultipleUser(id);
            return Ok(userOk);
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> GetUsers(int pageNumber = 1, int pageSize = 10)
        {
            var userOk = await _userService.GetUsers(pageNumber,pageSize);
            return Ok(userOk);
        }
    }
}
