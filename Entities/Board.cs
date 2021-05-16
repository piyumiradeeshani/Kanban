using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Board
    {
        public Board()
        {
            BoardUsers = new HashSet<BoardUser>();
        }

        public int BoardId { get; set; }
        public string BoardName { get; set; }

        public virtual ICollection<BoardUser> BoardUsers { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
