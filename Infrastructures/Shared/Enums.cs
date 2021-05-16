using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructures.Shared
{
    public class Enums
    {
        public enum BoardUserRole
        {
            Owner,
            Assignee,
            PendingInvitee
        }
        public enum StatusValue
        {
            InternalServerError = 500,
            Ok = 200,
            NotFound = 404,
            BadRequest = 400
        }

    }
}
