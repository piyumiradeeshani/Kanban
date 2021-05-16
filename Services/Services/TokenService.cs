using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TokenService : ITokenService
    {
        public TokenService()
        {

        }
        public string TokenValidator(string header)
        {
            //Decode the JWT token of the logged user which is sent in the Request header 

            //Validate the recieved JWT token

            string validatedUserName = "";
            //check whether the validation is true or false
            // validatedUserName = retrieved User Name from token

            string userName = (true) ? validatedUserName : null;

            return userName;


        }
        
    }
}
