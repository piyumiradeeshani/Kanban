using Entities;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Mappers
{
    public class UserViewModelToUser : IMapper<UserViewModel, User>
    {
        public User Map(UserViewModel userViewModel)
        {
            return new User()
            {
                Username = userViewModel.Username,
                Email = userViewModel.Email
            };
        }
    }
}
