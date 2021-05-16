using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            TaskUsers = new HashSet<TaskUser>();
        }

        public int TaskId { get; set; }
        public int BoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderNo { get; set; }
        public int? StatusId { get; set; }
        public int? TagId { get; set; }
        public virtual Status Status { get; set; }
        public virtual Board Board { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TaskUser> TaskUsers { get; set; }
    }
}
