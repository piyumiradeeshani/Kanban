using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
