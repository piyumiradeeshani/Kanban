using Entities;
using Services.Models;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Entities.Task;

namespace Services.Mappers
{
    public class BoardToBoardTask : IMapper<List<Board>, List<BoardTask>>
    {
        public List<BoardTask> Map(List<Board> board)
        {
            List<BoardTask> listBoardTask = new List<BoardTask>();

            foreach (var b in board)
            {
                List<TaskModel> listTask = new List<TaskModel>();
                foreach (var t in b.Tasks)
                {
                    List<string> taskUserTask = new List<string>();

                    foreach (var tu in t.TaskUsers)
                    {
                        var uName = tu.User.Username;
                        taskUserTask.Add(uName);
                    }

                    List<CommentModel> taskComment = new List<CommentModel>();
                    foreach (var co in t.Comments)
                    {
                        var comModel = new CommentModel()
                        {
                             Description = co.Description,
                        };
                        taskComment.Add(comModel);
                    }

                    var newTask = new TaskModel()
                    {
                        Title = t.Title,
                        Description = t.Description,
                        OrderNo = t.OrderNo,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        StatusType = t.Status == null ?null: t.Status.StatusType,
                        Tagname = t.Tag == null ? null : t.Tag.Tagname,
                        TaskUsers = taskUserTask,
                        Comments = taskComment
                    };
                    listTask.Add(newTask);
                }
                var newBoardTask = new BoardTask()
                {
                    BoardName = b.BoardName,
                    Tasks = listTask
                };
                listBoardTask.Add(newBoardTask);
            }
            return listBoardTask;
        }
    }

}
