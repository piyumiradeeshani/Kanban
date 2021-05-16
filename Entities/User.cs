using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
            BoardUsers = new HashSet<BoardUser>();
            TaskUsers = new HashSet<TaskUser>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BoardUser> BoardUsers { get; set; }
        public virtual ICollection<TaskUser> TaskUsers { get; set; }
    }
}
