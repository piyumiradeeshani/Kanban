using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Services.Contracts;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Shared;
using Web.ViewModels;
using static Infrastructures.Shared.Enums;

namespace Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly ILogger<BoardController> _logger;
        private readonly IMapper<UserViewModel, User> _userViewModelToUser;
        public BoardController(IBoardService boardService, ITokenService tokenService,
            IEmailService emailService, ILogger<BoardController> logger, IMapper<UserViewModel, User> UserViewModelToUser)
        {
            _boardService = boardService;
            _tokenService = tokenService;
            _emailService = emailService;
            _logger = logger;
            _userViewModelToUser = UserViewModelToUser;
        }
        //Create a board
        [HttpPost]
        public IActionResult Post([FromBody] Board board)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the BoardService.CreateBoard method as below
            try
            {
                if (board == null)
                {
                    result = new ObjectResult("")
                    {
                        StatusCode = (int?)StatusValue.BadRequest

                    };
                }
                string username = "Ann";
                 _boardService.CreateBoard(board, username);
                result = new ObjectResult("")
                {
                    StatusCode = (int?)StatusValue.Ok,

                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                reponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                result = new ObjectResult(reponse)
                {
                    Value = reponse,
                    StatusCode = (int?)StatusValue.InternalServerError
                };

            }
            return result;
        }

        //Update a board
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Board board)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            if (id <= 0 || board == null)
            {
                result = new ObjectResult(board)
                {
                    StatusCode = (int?)StatusValue.BadRequest
                };
            }

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the BoardService.EditBoard method as below

            try
            {
                string username = "Ann";
                var boardResponse = _boardService.EditBoard(id, username, board);
                result = new ObjectResult(boardResponse)
                {
                    StatusCode = (int?)StatusValue.Ok,

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                reponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                result = new ObjectResult(reponse)
                {
                    Value = reponse,
                    StatusCode = (int?)StatusValue.InternalServerError
                };
            }
            return result;
        }

        //Delete a board
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            if (id <= 0)
            {
                result = new ObjectResult("")
                {
                    StatusCode = (int?)StatusValue.BadRequest
                };
            }

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the BoardService.DeleteBoard method as below

            try
            {
                string username = "Ann";
                _boardService.DeleteBoard(id, username);
                result = new ObjectResult("")
                {
                    StatusCode = (int?)StatusValue.Ok,

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                reponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                result = new ObjectResult(reponse)
                {
                    Value = reponse,
                    StatusCode = (int?)StatusValue.InternalServerError
                };
            }
            return result;

        }

        //Get the board and relevent tasks
        [Route("tasks")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            // Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the BoardService.GetBoardTask method as below 

            try
            {
                string username = "Ann";
                var boardResponse = await _boardService.GetBoardTask(username);
                result = new ObjectResult(boardResponse)
                {
                    StatusCode = (int?)StatusValue.Ok,

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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

        //Invite to other users to board by creator
        [Route("{id}/users")]
        [HttpPost]
        public IActionResult InviteUsersToBoard(int id, string userName, UserViewModel userViewModel)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the BoardService.InviteUsersToBoard method as below

            try
            {
                string username = "Ann";
                var user = _userViewModelToUser.Map(userViewModel);
                Board board= _boardService.InviteUsersToBoard(id, username, user);
                //After calling the above InviteUsersToBoard method in the service, if the response is not null then details of the board and user can retrieve.
                
                // call the EmailService.SendInvitationEmails(Board board)

                result = new ObjectResult("")
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
