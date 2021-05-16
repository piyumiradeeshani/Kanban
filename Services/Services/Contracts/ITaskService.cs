using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Services.Models;
using Task = Entities.Task;
namespace Services.Services.Contracts
{
    public interface ITaskService
    {
        public void CreateTask(int id,Task board, string username);
        public Task EditTask(int board_id, int task_id, string username, Task task);
        public void DeleteTask(int board_id, int task_id,string userName);
        public void AssignUsersToTasks(int boardId, int taskId, User user, string username);
    }
}
