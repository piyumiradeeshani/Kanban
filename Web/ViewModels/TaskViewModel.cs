using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class TaskViewModel
    {
        public int BoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderNo { get; set; }
        public int? StatusId { get; set; }
        public int? TagId { get; set; }
        public List<string> Comments { get; set; }
     
    }
}
