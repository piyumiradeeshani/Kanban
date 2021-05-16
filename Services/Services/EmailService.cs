using Entities;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        public void SendInvitationEmails(Board board)
        {

            //Prepare the email to be sent
            //if the recieved object is not null then encrypt relevent board, user data with the url to resource.  
            //Add email body

            //Connect and authenticate with the SMTP server

            //Send email(Send the invitaion link to the relevent user.)
        }
    }
}
