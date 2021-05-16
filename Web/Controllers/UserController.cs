using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Shared;
using static Infrastructures.Shared.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //boards are created by a user
        [Route("{id}/boards")]
        [HttpGet]
        public async Task<IActionResult> GetUserCreatedBoards(int id)
        {

            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            // Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the UserService.GetuserOwnedBoards method

            try
            {
                string username = "Ann";
                var boardResponse = await _userService.GetuserOwnedBoards(id, username);
                result = new ObjectResult(boardResponse)
                {
                    StatusCode = (int?)StatusValue.Ok,

                };
            }
            catch (Exception ex)
            {

                reponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                result = new ObjectResult(reponse)
                {
                    Value = reponse,
                    StatusCode = (int?)StatusValue.InternalServerError,

                };
            }
            return result;
        }


    }
}
