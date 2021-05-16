using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskUser
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
