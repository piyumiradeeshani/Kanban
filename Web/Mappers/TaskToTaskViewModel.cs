using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Web.ViewModels;
using Task = Entities.Task;

namespace Web.Mappers
{
    public class TaskToTaskViewModel : IMapper<Task,TaskViewModel>
    {
        public TaskViewModel Map(Task task)
        {
            List<string> listComment = new List<string>();
            if (task.Comments != null)
            {
                foreach (var c in task.Comments)
                {
                    listComment.Add(c.Description);
                };
            }
            var newTask = new TaskViewModel()
            {
                BoardId = task.BoardId,
                Comments = new List<string>(),
                Title = task.Title,
                Description = task.Description,
                EndDate = task.EndDate,
                StartDate = task.StartDate,
                OrderNo = task.OrderNo,
                StatusId = task.StatusId,
                TagId = task.TagId
                
            };
            foreach (var cn in listComment)
            {
                newTask.Comments.Add(cn);
            };
            return newTask;
        }
    }
}



