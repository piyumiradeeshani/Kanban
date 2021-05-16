using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;

namespace Infrastructures.Repositories.Contracts
{
    public interface ITaskRepository
    {
        public void CreateTask(int id,Task task);
        public Task EditTask(int board_id, int task_id, Task task);
        public void DeleteTask(int board_id, int task_id);
        public void AssignUsersToTasks(int boardId, int taskId, User user);
    }
}
