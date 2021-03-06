using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;

namespace Services.Models
{
    public class BoardTask
    {
        public string BoardName { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }

    public class Tasks
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderNo { get; set; }
        public int? StatusId { get; set; }
        public int? TagId { get; set; }
        //public Status Status { get; set; }

        //public Tag Tag { get; set; }
    }

}
