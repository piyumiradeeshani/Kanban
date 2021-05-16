using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Status
    {
        public Status()
        {
        }

        public int StatusId { get; set; }
        public string StatusType { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
