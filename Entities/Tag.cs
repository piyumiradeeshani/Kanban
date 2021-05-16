using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Tag
    {
        public Tag()
        {
            Tasks = new HashSet<Task>();
        }

        public int TagId { get; set; }
        public string Tagname { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
