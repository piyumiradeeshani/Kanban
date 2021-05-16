using Infrastructures.Repositories.Contracts;
using Services.Models;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;
using Services.Shared;

namespace Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository )
        {
            _taskRepository = taskRepository;
        }
        public void CreateTask(int id, Task task, string username)
        {
            //Implementaion to check whether user has authorization to the board relevent to this task.
            //Use the board id and user name which are sent in the input for this purpose

            _taskRepository.CreateTask(id,task);
            
        }
        public Task EditTask(int board_id, int task_id, string username, Task task)
        {
            //Implementaion to check whether user has authorization to the edit sent task 
            //Use the task id and user name which are sent in the input for this purpose

            Task taskResponse = _taskRepository.EditTask(board_id, task_id, task);
            return taskResponse;
        }

        public void DeleteTask(int board_id, int task_id, string userName)
        {
            //Implementaion to check whether user has authorization to delete the sent task 
            //Use the task id and user name which are sent in the input for this purpose

             _taskRepository.DeleteTask(board_id, task_id);
            
        }

        public void AssignUsersToTasks(int boardId, int taskId, User user, string username)
        {
            //Check whether the user is authorized for relevent board

            _taskRepository.AssignUsersToTasks(boardId, taskId, user);
 

        }

    }
}
