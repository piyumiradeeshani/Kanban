using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;
using Web.Shared;
using static Infrastructures.Shared.Enums;
using Microsoft.Extensions.Logging;
using Web.ViewModels;
using Services.Shared;

namespace Web.Controllers
{
    [Route("api/v1/board/{board_id}/{controller}")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;
        private readonly IMapper<TaskViewModel, Task> _taskViewModelToTask;
        private readonly IMapper<Task, TaskViewModel> _taskToTaskViewModel;
        private readonly IMapper<UserViewModel, User> _userViewModelToUser;
        public TaskController(ITaskService taskService, ILogger<TaskController> logger,
            IMapper<TaskViewModel, Task> taskViewModelToTask, IMapper<Task, TaskViewModel> taskToTaskViewModel, IMapper<UserViewModel, 
                User> UserViewModelToUser)
        {
            _taskService = taskService;
            _logger = logger;
            _taskViewModelToTask = taskViewModelToTask;
            _taskToTaskViewModel = taskToTaskViewModel;
            _userViewModelToUser = UserViewModelToUser;
        }

        
        [HttpPost]
        public IActionResult Post(int board_id, [FromBody] TaskViewModel taskmodel)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the TaskService.CreateTask method as below

            try
            {
                if (taskmodel == null)
                {
                    result = new ObjectResult("")
                    {
                        StatusCode = (int?)StatusValue.BadRequest

                    };
                }
                string username = "Ann";
                var task = _taskViewModelToTask.Map(taskmodel);
                _taskService.CreateTask(board_id, task, username);
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
        [Route("{task_id}")]
        [HttpPut]
        public IActionResult Put(int board_id, int task_id, [FromBody] TaskViewModel taskmodel)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            if (board_id <= 0 || task_id <= 0 || taskmodel == null)
            {
                result = new ObjectResult(taskmodel)
                {
                    StatusCode = (int?)StatusValue.BadRequest
                };
            }

            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the TaskService.EditTask method as below


            try
            {
                string username = "Ann";
                var task = _taskViewModelToTask.Map(taskmodel);
                var taskResponse = _taskService.EditTask(board_id, task_id, username, task);
                var response = _taskToTaskViewModel.Map(taskResponse);
                result = new ObjectResult(response)
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

        [Route("{task_id}")]
        [HttpDelete]
        public IActionResult Delete(int board_id, int task_id)
        {
            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            if (board_id <= 0 || task_id<=0)
            {
                result = new ObjectResult("")
                {
                    StatusCode = (int?)StatusValue.BadRequest
                };
            }
            //Call the TokenValidator in TokenService with the token in the Request header
            //_tokenService.TokenValidator(string header)

            //if username is null return Unaithorized error(401)

            //if the username is not null call the TaskService.DeleteTask method as below

            try
            {
                string username = "Ann";
                _taskService.DeleteTask(board_id, task_id, username);
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

        [Route("{task_id}/users")]
        [HttpPost]
        public  IActionResult AssignUsersToTasks(int board_id, int task_id, UserViewModel userViewModel)
        {

            IActionResult result = new ObjectResult(false);
            BaseResponse reponse = null;

            // call the TokenValidator in TokenService

            //if username is null return Bad request(Invalid Token) 

            //if the username is not null call the UserService.GetuserOwnedBoards method

            try
            {
                string username = "Ann";
                var user = _userViewModelToUser.Map(userViewModel);
                _taskService.AssignUsersToTasks(board_id, task_id, user, username);
              
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
                    StatusCode = (int?)StatusValue.InternalServerError,

                };
            }
            return result;
        }
    }
}
