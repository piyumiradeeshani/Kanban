using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;
using Entities;
using Task = Entities.Task;

namespace Web.Mappers
{
    public class TaskViewModelToTask : IMapper<TaskViewModel, Task>
    {
        public Task Map(TaskViewModel taskModel)
        {
            List<Comment> listComment = new List<Comment>();
            if (taskModel.Comments != null)
            {
                
                foreach (var c in taskModel.Comments)
                {
                    var commentObj = new Comment();
                    commentObj.Description = c;
                    listComment.Add(commentObj);
                };
            }
            var newTask = new Task()
            {

                Title = taskModel.Title,
                Description = taskModel.Description,
                EndDate = taskModel.EndDate,
                StartDate = taskModel.StartDate,
                OrderNo = taskModel.OrderNo,
                StatusId = taskModel.StatusId,
                TagId = taskModel.TagId
                //Comments = listComment,
            };
             foreach (var cn in listComment)
            {
                newTask.Comments.Add(cn);
            };
            return newTask;
        }
    }
}

