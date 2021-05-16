using Entities;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderNo { get; set; }
        //public int? StatusId { get; set; }
        //public int? TagId { get; set; }
        //public Status Status { get; set; }

        //public Tag Tag { get; set; }
        public string StatusType { get; set; }
        public string Tagname { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<string> TaskUsers { get; set; }



    }
}