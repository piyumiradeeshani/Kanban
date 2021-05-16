using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class BoardUser
    {
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public virtual Board Board { get; set; }
        public virtual User User { get; set; }
    }
}
