using Infrastructures.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;
using Infrastructures.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        KanbanContext _kanbanContext;
        
        public TaskRepository(KanbanContext kanbanContext)
        {
            _kanbanContext = kanbanContext;
        }
        public void CreateTask(int id,Task task)
        {
            //check where the board id is valid and then then inser task to table
            
             task.BoardId = id;
           if( _kanbanContext.Statuses.Where(s=>s.StatusId == task.StatusId).First() != null && _kanbanContext.Tags.Where(t => t.TagId == task.TagId).First() != null){
                _kanbanContext.Tasks.Add(task);
            }

            _kanbanContext.SaveChanges();
        }
        public Task EditTask(int board_id, int task_id, Task task)
        {
            var retrievedTask = _kanbanContext.Tasks.Where(b => b.TaskId == task_id && b.BoardId == board_id).First();
            retrievedTask.Title = task.Title==""? retrievedTask.Title: task.Title;
            retrievedTask.Description = task.Description == "" ? retrievedTask.Description : task.Description;
            retrievedTask.StartDate = task.StartDate.HasValue ? task.StartDate: retrievedTask.StartDate;
            retrievedTask.EndDate = task.EndDate.HasValue ? task.EndDate : retrievedTask.EndDate;
            retrievedTask.OrderNo = task.OrderNo == 0 ? retrievedTask.OrderNo : task.OrderNo;

            try
            {
                var retrievedStatusId = _kanbanContext.Statuses.Where(s => s.StatusType == task.Status.StatusType).First().StatusId;
                retrievedTask.StatusId = retrievedStatusId;
            }
            catch
            {
                retrievedTask.StatusId = retrievedTask.StatusId;
            }

            try
            {
                var retrievedTagId = _kanbanContext.Tags.Where(s => s.Tagname == task.Tag.Tagname).First().TagId;
                retrievedTask.StatusId = retrievedTagId;
            }
            catch
            {
                retrievedTask.TagId = retrievedTask.TagId;
            }

            _kanbanContext.Tasks.Update(retrievedTask);
            _kanbanContext.SaveChanges();
            _kanbanContext.Tasks.Include(c=>c.Comments).Where(b => b.TaskId == task_id && b.BoardId == board_id).First();
            return retrievedTask;

        }

        public void DeleteTask(int board_id, int task_id)
        {
            var retrievedTask = _kanbanContext.Tasks.Where(b => b.TaskId == task_id && b.BoardId == board_id).First();
            _kanbanContext.Tasks.Remove(retrievedTask);
            _kanbanContext.SaveChanges();

        }

        public void AssignUsersToTasks(int boardId, int taskId, User user)
        {
            //add data to taskuser
                var assignUser = _kanbanContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
                var validTask = _kanbanContext.Tasks.Where(t => t.TaskId == taskId && t.BoardId == boardId).FirstOrDefault();
                if ((assignUser != null) && validTask != null)
                {
                    var taskUser = new TaskUser()
                    {
                        TaskId = taskId,
                        UserId = assignUser.UserId
                    };
                    _kanbanContext.TaskUsers.Add(taskUser);
                    _kanbanContext.SaveChanges();

                }
        }
    }
}
