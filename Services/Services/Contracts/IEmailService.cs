using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface IEmailService
    {
        public void SendInvitationEmails(Board board);
    }
}
