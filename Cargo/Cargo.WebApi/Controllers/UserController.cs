using Cargo.Business.Dtos;
using Cargo.Business.Services;
using Cargo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
                
        }
        [HttpPost]
        public IActionResult Login(LoginUserRequest loginUserRequest)
        {
            var loginUserDto = new LoginUserDto()
            {
              Email = loginUserRequest.Email,
              Password = loginUserRequest.Password,
            };
            var userInfo=_userService.LoginUser(loginUserDto);
            if(userInfo is null) 
            {

                return NotFound();

            }
            return Ok(userInfo);
           
        }
        [HttpGet]
        public IActionResult Users()
        {
            var getCargoDtos = _userService.GetAllUser();
            
           var response=getCargoDtos.Select(x => new UserInfoResponse
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,


            }).ToList();

            return Ok(response);

        }
    }
}
